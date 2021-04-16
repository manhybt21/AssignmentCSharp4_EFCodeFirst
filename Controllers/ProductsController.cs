using AssignmentCSharp4_EFCodeFirst.Context;
using AssignmentCSharp4_EFCodeFirst.IServices;
using AssignmentCSharp4_EFCodeFirst.Models;
using AssignmentCSharp4_EFCodeFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Controllers
{
    public class ProductsController : Controller
    {
        private IProductServices _iProductServices;
        private readonly DatabaseContext _databaseContext;
        public ProductsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _iProductServices = new ProductServices(_databaseContext);
        }
        // GET: ProductsController
        public ActionResult Index()
        {
            try {
                var lstProduct = _iProductServices.GetLstProduct();
                return View(lstProduct);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ProductsController/Details/5
       

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewData["MaDanhMuc"] = new SelectList(_databaseContext.Categorys, "Id", "NameCategory");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (product.id == 0)
                    {
                        _iProductServices.addProduct(product);
                    }

                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            
            var product = _iProductServices.findId(id);
            ViewData["MaDanhMuc"] = new SelectList(_databaseContext.Categorys, "Id", "NameCategory", product.CategoryId);
            if (product == null||id==null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Product product)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["MaDanhMuc"] = new SelectList(_databaseContext.Categorys, "Id", "NameCategory", product.CategoryId);
                    _iProductServices.editProduct(product);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _databaseContext.Products
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _databaseContext.Products.FindAsync(id);
            _databaseContext.Products.Remove(product);
            await _databaseContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
