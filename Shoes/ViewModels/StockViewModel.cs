using Shoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoes.ViewModels
{
    public class StockViewModel
    {
        public IEnumerable<Shoe> Shoes { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}