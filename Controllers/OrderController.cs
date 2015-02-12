using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        Database1 db = new Database1();
        public ActionResult OrderForm(int id)
        {

            var p3 = db.Products.Find(id);
            return View(p3);    
        }

        public ActionResult Addtocart(int id)
        {
            var detail = db.Products.Find(id);
            Customer t1 = new Customer();
            Cart c1 = new Cart();
            Order o1 = new Order();
            t1.Name = Request["name"];
            t1.Email = Request["email"];
            t1.Address = Request["city"];
            t1.Conatct_No = Convert.ToInt32(Request["phone"]);
            t1.Oid = o1.Oid;
            c1.Oid = o1.Oid;
            c1.Pid = id;
            c1.totalCost = 0;
            c1.totalCost = detail.Price + c1.totalCost;
            c1.quantity = 1;
            o1.Payment = 00;
            o1.Status = "Done";
            DateTime now = DateTime.Now;
            String date = now.ToShortDateString();
            String time = now.ToShortTimeString();
            o1.Date = date;
            o1.Time = time;
            t1.Pid = id;
            db.Orders.Add(o1);
            db.Carts.Add(c1);
            db.Customers.Add(t1);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
            
           
        }


    }
}
