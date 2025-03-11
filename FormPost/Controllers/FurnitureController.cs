using FormPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace FormPost.Controllers
{
    public class FurnitureController : Controller
    {
        public ActionResult Index()
        {
            FurnitureDb db = new FurnitureDb(Properties.Settings.Default.FurnitureConStr);

            return View(new FurnitureIndexViewModel
            {
                Count = db.GetCount()
            });
        }

        public ActionResult ShowAdd()
        {
            return View();
        }

        public ActionResult Add(string name, string color, decimal price, int quantityInStock)
        {
            FurnitureDb db = new FurnitureDb(Properties.Settings.Default.FurnitureConStr);
            db.Add(new FurnitureItem
            {
                Name = name,
                Color = color,
                Price = price,
                QuantityInStock = quantityInStock
            });

            return Redirect("/furniture/index");
        }
    }

}

//Create a page that displays a list of People (or whatever interests you).
//On top of the page, have a link that says "Add Person". When this link
//is clicked, the user should be taken to a page that has a form that 
//has textboxes for firstname/lastname/age (or whatever thing you're doing).
//Beneath that, there should be a submit button. When the button is clicked,
//the person should get added to the database, and the user should be redirected
//back to the list of all the people.