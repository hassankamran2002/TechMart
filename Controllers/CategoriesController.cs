using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class CategoriesController : Controller
    {

        Database1 db = new Database1();

        public ActionResult Camera()
        {
            var pro = db.Categories.FirstOrDefault(y => y.CatName == "Camera");
            var q = (from x in db.Products where (x.catId == pro.CatId) select x);
            return View(q.ToList());
          
        }

        public ActionResult Laptops()
        {
            var pro = db.Categories.FirstOrDefault(y => y.CatName == "Laptops");
            var q = (from x in db.Products where (x.catId == pro.CatId) select x);

            return View(q.ToList());
         
        }
        public ActionResult Mobile()
        {
            var pro = db.Categories.FirstOrDefault(y => y.CatName == "Mobile");
            var q = (from x in db.Products where (x.catId == pro.CatId) select x);
            return View(q.ToList());
            
        }
        
        public ActionResult Tablets()
        {
            var pro = db.Categories.FirstOrDefault(y => y.CatName == "Tablets");
            var q = (from x in db.Products where (x.catId == pro.CatId) select x);
            return View(q.ToList());
            
        }

        public ActionResult NewArrival()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var p3 = db.Products.Find(id);
            return View(p3);
        }

    }
}
