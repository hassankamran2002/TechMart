using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CheckUName()
        {
            using (Database1 db = new Database1())
            {
                string userName = Request["UserName"];

                var q = (from x in db.CustomerLogins where (x.Username == userName) select x.Username).FirstOrDefault();

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

        public ActionResult RegisterAccount(CustomerLogin c)
        {

            using (Database1 db = new Database1())
            {
                var maxValue = (from z in db.CustomerLogins select z.Id).Max();
                c.Id = maxValue + 1;
                db.CustomerLogins.Add(c);
                db.SaveChanges();
                
            }
            return RedirectToAction("Index", "Home");
        }  
    }
}
