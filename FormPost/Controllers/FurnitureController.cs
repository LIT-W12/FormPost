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
                Count = db.GetCount(),
                FurnitureItems = db.GetAll()
            });
        }

        public ActionResult ShowAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FurnitureItem item)
        {
            FurnitureDb db = new FurnitureDb(Properties.Settings.Default.FurnitureConStr);
            db.Add(item);
            return Redirect("/furniture/index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            FurnitureDb db = new FurnitureDb(Properties.Settings.Default.FurnitureConStr);
            db.Delete(id);
            return Redirect("/furniture/index");
        }

        public ActionResult Edit(int id)
        {
            FurnitureDb db = new FurnitureDb(Properties.Settings.Default.FurnitureConStr);
            FurnitureItem item = db.GetById(id);
            //if (item == null)
            //{
            //    return Redirect("/furniture/index");
            //}
            return View(new EditFurnitureViewModel
            {
                Item = item
            });
        }

        [HttpPost]
        public ActionResult Update(FurnitureItem item)
        {
            FurnitureDb db = new FurnitureDb(Properties.Settings.Default.FurnitureConStr);
            db.Update(item);
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