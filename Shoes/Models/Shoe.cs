using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shoes.Models
{
    public class Shoe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        //[Required]
        //public Image Images { get; set; }
        //public int ImagesId { get; set; }

        public bool IsEnabled { get; set; }

        public DateTime Updated { get; set; }
    }
}