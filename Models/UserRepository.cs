
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class UserRepository:IUser
    {
        public void SaveProduct(Product p1, string catname)
        {
            using (Database1 db = new Database1())
            {

                var c = (from x in db.Categories where x.CatName == catname select x);
                Category c1 = new Category();
                foreach (var z in c)
                {
                    c1 = z;
                }
                if (c.Count() == 0)
                {
                    Category cat = new Category();
                    cat.CatName = catname;
                    db.Categories.Add(cat);

                    db.SaveChanges();
                    var maxValue = (from z in db.Categories select z.CatId).Max();
                    p1.catId = maxValue;
                    db.Products.Add(p1);
                    db.SaveChanges();
                    
                }
                else
                {
                    
                    p1.catId = c1.CatId;
                    db.Products.Add(p1);
                    db.SaveChanges();
                }
               
            }
        }
        public void SaveCategory(Category c1)
        {
            using (Database1 db = new Database1())
            {
                db.Categories.Add(c1);
                db.SaveChanges();
            }
        }
        public Category ViewEditCategory(int id)
        {
            using (Database1 db = new Database1())
            {
                return db.Categories.Find(id);
            }
        }
        public void EditCategory(int id, Category c)
        {
            using (Database1 db = new Database1())
            {
                var c2 = db.Categories.Find(id);
                c2.CatName = c.CatName;
                db.SaveChanges();
            }
        }
        public void EditProduct(int id , Product p)
        {
            using (Database1 db = new Database1())
            {
                var p2 = db.Products.Find(id);
                p2.Name = p.Name;
                p2.Price = p.Price;
                p2.catId = p.catId;

                db.SaveChanges();
            }
        }
        public Product ViewEditProduct(int id)
        {
            using (Database1 db = new Database1())
            {
                return db.Products.Find(id);
            }
        }
        public List<Category> ViewCategory()
        {
            using (Database1 db = new Database1())
            {
                return db.Categories.ToList();
            }
        }
        public List<Product> ViewProduct()
        {
            using (Database1 db = new Database1())
            {
                return db.Products.ToList();
            }
        }
        public List<Customer> ViewCustomer()
        {
            using (Database1 db = new Database1())
            {
                return db.Customers.ToList();
            }
        }
        public List<Order> ViewOrder()
        {
            using (Database1 db = new Database1())
            {
                return db.Orders.ToList();
            }
        }
    }
}