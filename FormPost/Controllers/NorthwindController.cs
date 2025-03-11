using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormPost.Models;

namespace FormPost.Controllers
{
    public class NorthwindController : Controller
    {
        public ActionResult SearchProducts()
        {
            return View();
        }

        public ActionResult SearchResults(int min, int max)
        {
            NorthwindDb db = new NorthwindDb(Properties.Settings.Default.ConStr);
            SearchProductsViewModel vm = new SearchProductsViewModel
            {
                Products = db.SearchProducts(min, max),
                MinStock = min,
                MaxStock = max
            };
            return View(vm);
        }
    }
}