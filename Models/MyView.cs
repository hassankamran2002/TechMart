using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Models;
namespace MvcApplication2.Models
{
    public class MyView
    {
        
            private List<Product> p;
            private List<Category> c;
            public MyView(List<Product> p1, List<Category> c1)
            {
                p = p1;
                c = c1;
            }

            public List<Product> getNewProduct()
            {
                
                return p;
            }

            public List<Category> getCategories()
            {
                return c;
            }
    }
}