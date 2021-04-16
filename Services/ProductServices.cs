using AssignmentCSharp4_EFCodeFirst.Context;
using AssignmentCSharp4_EFCodeFirst.IServices;
using AssignmentCSharp4_EFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Services
{
    public class ProductServices:IProductServices

    {
        private readonly DatabaseContext _context;
        private List<Product> _lstProduct;
        public ProductServices(DatabaseContext context)
        {

            _lstProduct = new List<Product>();
            _context = context;
            GetLstProduct();
        }
        public List<Product> GetLstProduct()
        {
            _lstProduct = _context.Products.ToList();
            return _lstProduct;
        }
        public void addProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void editProduct(Product product)
        {
            var cus =  _context.Products.Find(product.id);
            cus.NameProduct = product.NameProduct;
            cus.Price = product.Price;
            cus.Image = product.Image;
            cus.Desciption = product.Desciption;
            cus.CategoryId = product.CategoryId;
            _context.Products.Update(cus);
            _context.SaveChanges();
        }
        public string deleteProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.id == productId);
            if (product != null) {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return "Xoá Thành Công";
        }
        public Product findId(int productId)
        {
            return _context.Products.SingleOrDefault(c => c.id == productId);
        }
        public bool checkIdProduct(int productId)
        {
            return _lstProduct.Any(x => x.id == productId);
        }
        public Product getProductObj(int productId)
        {
            return _lstProduct.Where(x => x.id == productId).FirstOrDefault();
        }
    }
}
