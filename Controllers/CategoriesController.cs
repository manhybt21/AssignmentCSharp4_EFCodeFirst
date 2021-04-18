using AssignmentCSharp4_EFCodeFirst.Context;
using AssignmentCSharp4_EFCodeFirst.IServices;
using AssignmentCSharp4_EFCodeFirst.Models;
using AssignmentCSharp4_EFCodeFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryServices _iCategoryServices;
        private readonly DatabaseContext _databaseContext;
        public CategoriesController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _iCategoryServices = new CategoryServices(_databaseContext);
        }
        // GET: CategoriesController
        public ActionResult Index()
        {
            try
            {
                var lstCategory = _iCategoryServices.GetLstCategory();
                return View(lstCategory);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (category.Id == 0)
                    {
                        _iCategoryServices.addCategory(category);
                    }
                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _iCategoryServices.findId(id);
            if (category == null || id == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iCategoryServices.editCategory(category);
                }
                 return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }
        public IActionResult Delete(int id)
        {
            var category = _databaseContext.Categorys.FirstOrDefault(x => x.Id == id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id,string result)
        {
            var getIdCateInProduct = _databaseContext.Products.Where(x => x.CategoryId == id).ToList();
            _databaseContext.RemoveRange(getIdCateInProduct);
            _databaseContext.SaveChangesAsync();
            var category = await _databaseContext.Categorys.FindAsync(id);
            _databaseContext.Remove(category);
            _databaseContext.SaveChangesAsync();
            return RedirectToAction("Index","categories");
        }
    }
}
