using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication2.Models
{
    public interface IUser
    {
        void SaveProduct(Product p,string p2);
        void SaveCategory(Category c1);
        Category ViewEditCategory(int id);
        void EditCategory(int id , Category c);
        void EditProduct(int id , Product p);
        Product ViewEditProduct(int id);
        List<Category> ViewCategory();
        List<Product> ViewProduct();
        List<Customer> ViewCustomer();
        List<Order> ViewOrder();
    }
}
