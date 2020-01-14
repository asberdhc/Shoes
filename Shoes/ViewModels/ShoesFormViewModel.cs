using Shoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoes.ViewModels
{
    public class ShoesFormViewModel
    {
        public Shoe Shoe { get; set; }
        public List<Image> Images { get; set; }
    }
}