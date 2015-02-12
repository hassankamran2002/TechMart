using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{

    public class HomeController : Controller
    {

        Database1 db = new Database1();

        public ActionResult Index()
        {
            var pro=db.Categories.FirstOrDefault(y=> y.CatName=="NewArrival");
            var q = (from x in db.Products where (x.catId == pro.CatId) select x);
            
            MyView t = new MyView(q.ToList(), db.Categories.ToList());
            return View(t);
        }

        public ActionResult Contact()
        {
           

            return View();
        }

        public ActionResult Faq()
        {
          

            return View();
        }

        public JsonResult Search()
        {

            string nam = Request["UserName"];

            var q = from x in db.Products where (x.Name.Equals(nam)) select x;

            if (q != null)
            {
               
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
      
                return this.Json(false, JsonRequestBehavior.AllowGet);
            }
            
        }

       
    }
}
