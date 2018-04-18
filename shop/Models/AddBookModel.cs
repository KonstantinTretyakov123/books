using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop.Models
{
    public class AddBookModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public string PageCount { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
    }
}