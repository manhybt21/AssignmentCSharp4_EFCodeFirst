using AssignmentCSharp4_EFCodeFirst.Context;
using AssignmentCSharp4_EFCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Controllers
{
    public class ViewProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ViewProductsController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: ViewProductsController
        public ActionResult Index(string searchString)
        {
            var databaseContext = from n in _context.Products
                                  select n;
            if (!String.IsNullOrEmpty(searchString))
            {
                databaseContext = databaseContext.Where(s => s.NameProduct.Contains(searchString));
            }
            
            return View(databaseContext);
        }
        public IActionResult ListCart()
        {
            var view = _context.Carts.Where(x => x.Customer.EmailAddress == HttpContext.Session.GetString("Email")).ToList();
            return View(view);
        }
        public IActionResult addCart(int productId)
        {
            Cart gh=new Cart();
            var customer = _context.Customers.Where(x => x.EmailAddress == HttpContext.Session.GetString("Email")).FirstOrDefault();
            var product = _context.Products.Find(productId);
            var cartItem = _context.Carts.Where(x => x.Product.id == productId&&x.Customer.EmailAddress==customer.EmailAddress).FirstOrDefault();
            if (cartItem!=null)
            {
                cartItem.Quantity++;
                cartItem.Amount = cartItem.Price * cartItem.Quantity;
                _context.Carts.Update(cartItem);
                _context.SaveChanges();
                return RedirectToAction("ListCart");
            }
            else
            {
               
                gh = new Cart() {Product= product,
                        NameProduct = product.NameProduct,
                        Price = product.Price,
                        Quantity = 1,
                        Amount = product.Price,
                        Customer = customer
                    };
                _context.Carts.Add(gh);
                _context.SaveChanges();
                return RedirectToAction("ListCart");
            }
            
        }
       public IActionResult Update(int id, int quantity)
        {
            var update = _context.Carts.Find(id);
            update.Quantity = quantity;
            update.Amount = quantity * update.Price;
            _context.Update(update);
            _context.SaveChanges();
            return RedirectToAction("ListCart", "ViewProducts");
        }
        public IActionResult deleteCart(int id)
        {
            var delete = _context.Carts.Find(id);
            _context.Carts.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("ListCart", "ViewProducts");
        }
    }
}
