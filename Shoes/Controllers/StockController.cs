using Shoes.Models;
using Shoes.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoes.Controllers
{
    public class StockController : Controller
    {
        private ApplicationDbContext _context;

        public StockController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Stock
        public ActionResult Index()
        {
            var viewModel = new StockViewModel
            {
                Shoes = _context.Shoes.ToList(),
                Images = _context.Images.Include(i => i.Shoe).ToList()
            };
            return View(viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var viewModel = new ShoesFormViewModel
            {
                Shoe = _context.Shoes.FirstOrDefault(s => s.Id == Id),
                Images = _context.Images.Where(i => i.ShoeId == Id).ToList()
            };
            if (viewModel.Shoe != null)
                return View("ShoesForm", viewModel);
            return HttpNotFound();
        }

        public ActionResult Save(Shoe shoe)
        {
            if(shoe.Id == 0)
                _context.Shoes.Add(shoe);
            else
            {
                var shoeInDb = _context.Shoes.First(s => s.Id == shoe.Id);
                shoeInDb.Name = shoe.Name;
                shoeInDb.Description = shoe.Description;
                shoeInDb.Price = shoe.Price;
                shoeInDb.Updated = shoe.Updated;
                shoeInDb.IsEnabled = shoe.IsEnabled;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Stock");
        }

        [HttpPost]
        public ActionResult AddImage(Shoe shoe, HttpPostedFileBase file)
        {
            byte[] rawImg;
            using (BinaryReader br = new BinaryReader(file.InputStream))
            {
                rawImg = br.ReadBytes(file.ContentLength);
            }
            _context.Images.Add(new Image
            {
                RawImage = rawImg,
                ColorHex = "",
                ShoeId = 1//viewModel.Shoe.Id
            });

            return RedirectToAction("Stock/Edit/" + 1 /*viewModel.Shoe.Id*/, "Stock");
        }
    }
}