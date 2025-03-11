using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormPost.Models;

namespace FormPost.Controllers
{
    public class PostDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormPost(string value)
        {
            return View(new PostDemoViewModel
            {
                Value = value
            });
        }

        public ActionResult HiddenDemo()
        {
            return View();
        }
    }
}