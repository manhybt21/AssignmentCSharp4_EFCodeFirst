using AssignmentCSharp4_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.IServices
{
    public interface IProductServices
    {
        List<Product> GetLstProduct();
        Product findId(int productId);
        void addProduct(Product product);
        void editProduct(Product product);
        string deleteProduct(int productId);
        bool checkIdProduct(int productId);
        Product getProductObj(int productId);
    }
}
