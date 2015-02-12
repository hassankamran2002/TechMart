using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class AdminController : Controller
    {
        Database1 db = new Database1();
        //
        // GET: /Admin/
        readonly IUser IUser_obj;
        public AdminController(IUser u)
        {
            this.IUser_obj = u;
        }
        public ActionResult Panel()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginConfirm()
        {
            var t= Request["t1"];
            var t2 = Request["t2"];
            var q = (from x in db.Admins where (x.username == t && x.password == t2   ) select x).FirstOrDefault();
            if ( q != null )
            {

                return RedirectToAction("Panel");
            }
            else
            {
               
                return RedirectToAction("LoginAgain");
            }

           

        }

        public ActionResult LoginAgain()
        {
            return View();
        }
        public ActionResult AddAdmin()
        {
            return View();
        }

        public ActionResult SaveAdmin()
        {
            string us = Request["t1"];
            string pas =  Request["t2"];
            Admin a = new Admin();
            a.username = us;
            a.password = pas;
            db.Admins.Add(a);
            db.SaveChanges();
            return RedirectToAction("Panel");
        }
        public ActionResult AddCategory()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult SaveCategory(Category c1)
        {
            IUser_obj.SaveCategory(c1);
            return View("Panel");
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(Product p1)
        {


            string tp = Request["t1"];
            String img = null;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
               img = @"/Images/Data/" + tp+ "/" +  file.FileName ; 
                file.SaveAs(Server.MapPath(img));
            }


            p1.Image = img;
            
            IUser_obj.SaveProduct(p1,tp);
            return View("Panel");
        }
        public ActionResult ViewCategory()
        {
            return View(IUser_obj.ViewCategory());
        }
        public ActionResult ViewProduct()
        {
            return View(IUser_obj.ViewProduct());
        }
        public ActionResult ViewCustomer()
        {
            return View(IUser_obj.ViewCustomer());
        }
        public ActionResult ViewOrder()
        {
            return View(IUser_obj.ViewOrder());
        }
        public ActionResult ViewEditCategory(int id)
        {
            var c2 = IUser_obj.ViewEditCategory(id);
            return View(c2);
        }
        public ActionResult EditCategory(int id)
        {
            var c2 = IUser_obj.ViewEditCategory(id);
            c2.CatName = Request["cat_name"];
            IUser_obj.EditCategory(id, c2);
            return View("Panel");
        }
        public ActionResult ViewEditProduct(int id)
        {
            var p2 = IUser_obj.ViewEditProduct(id);
            return View(p2);
        }
        public ActionResult EditProduct(int id)
        {
            var p2 = IUser_obj.ViewEditProduct(id);
            p2.Name= Request["product_name"];
            p2.Price = Convert.ToInt32(Request["product_price"]);
            IUser_obj.EditProduct(id, p2);

            return View("Panel");
        }
        public ActionResult ViewDeleteCategory(int id)
        {
            var c2 = IUser_obj.ViewEditCategory(id);
            return View(c2);
        }
        public ActionResult DeleteCategory(int id)
        {
            var c2 = db.Categories.Find(id);

            db.Categories.Remove(c2);
            db.SaveChanges();
            return View("Panel");
        }
        public ActionResult ViewDeleteProduct(int id)
        {
            var p2 = IUser_obj.ViewEditProduct(id);
            return View(p2);
        }
        public ActionResult DeleteProduct(int id)
        {
            var p2 = db.Products.Find(id);
            db.Products.Remove(p2);
            db.SaveChanges();
            return View("Panel");
        }
    }
}
