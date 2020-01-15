using Shoes.Models;
using Shoes.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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

            return View("ShoesForm", new ShoesFormViewModel());
        }

        [HttpPost]
        public ActionResult Save(Shoe shoe)
        {
            if(shoe.Id == 0)
            {
                _context.Shoes.Add(shoe);
                _context.SaveChanges();
                shoe.Id = _context.Shoes.OrderByDescending(s => s.Id).First().Id;
                _context.Images.Add(new Image
                {
                    RawImage = _context.Images.First(i => i.Id == 5).RawImage,
                    ColorHex = "",
                    ShoeId = shoe.Id,
                });
                _context.SaveChanges();
            }
            else
            {
                var shoeInDb = _context.Shoes.First(s => s.Id == shoe.Id);
                shoeInDb.Name = shoe.Name;
                shoeInDb.Description = shoe.Description;
                shoeInDb.Price = shoe.Price;
                shoeInDb.Updated = shoe.Updated;
                shoeInDb.IsEnabled = shoe.IsEnabled;
                _context.SaveChanges();
            }
            return RedirectToAction("Edit/" + shoe.Id, "Stock");
        }

        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase file, Shoe shoe)
        {
            try
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
                    ShoeId = shoe.Id,
                    Shoe = _context.Shoes.First(s => s.Id == shoe.Id)                    
                });
                _context.SaveChanges();
            }catch (DbEntityValidationException e)
            {
                var ex = e;
            }

            return RedirectToAction("Edit/" + shoe.Id, "Stock");
        }
    }
}