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
        public List<Cart> ViewListCart()
        {
           var view = _context.Carts.Where(x=>x.Customer.EmailAddress==HttpContext.Session.GetString("Email")).ToList();
            return new List<Cart>();
        }
        public IActionResult addCart(int productId)
        {
            Cart gh=new Cart();
            var product = _context.Products.Find(productId);
            var cart = ViewListCart();
            var cartItem = cart.Find(x=>x.Product.id == productId);
            if (cartItem!=null)
            {
              gh.Quantity =  cartItem.Quantity++;
                gh.Amount = gh.Quantity * gh.Price;
                _context.Update(gh);
                _context.SaveChanges();
            }
            if(cartItem==null)
            {
                var customer = _context.Customers.Where(x => x.EmailAddress == HttpContext.Session.GetString("Email")).FirstOrDefault();
                gh = new Cart() {Product= product,
                        NameProduct = product.NameProduct,
                        Price = product.Price,
                        Quantity = 1,
                        Amount = product.Price,
                        Customer = customer
                    };
                _context.Carts.Add(gh);
                _context.SaveChanges();
            }
            return RedirectToAction("ListCart");
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
