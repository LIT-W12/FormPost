using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormPost.Models
{
    public class FurnitureIndexViewModel
    {
        public int Count { get; set; }
        public List<FurnitureItem> FurnitureItems { get; set; }
    }
}