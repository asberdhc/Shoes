using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shoes.Models
{
    public class Image
    {
        public int Id { get; set; }

        public byte[] RawImage { get; set; }

        public string ColorHex { get; set; }

        [Required]
        public Shoe Shoe { get; set; }
        public int ShoeId { get; set; }
    }
}