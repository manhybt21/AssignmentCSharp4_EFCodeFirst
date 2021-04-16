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
    public class CustomersController : Controller
    {
        private ICustomerServices _iCustomerServices;
        private readonly DatabaseContext _databaseContext;
        public CustomersController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _iCustomerServices = new CustomerServices(_databaseContext);
        }
        // GET: CustomersController
        public ActionResult Index()
        {
            try
            {
                var lstCustomer = _iCustomerServices.GetLstCustomer();
                return View(lstCustomer);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CustomersController/Details/5
       
        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer cus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (cus.Id == 0)
                    {
                        _iCustomerServices.addCustomer(cus);
                    }

                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var cus = _iCustomerServices.findId(id);
            if (cus == null || id == null)
            {
                return NotFound();
            }
            return View(cus);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer cus)
        {
            
                if (ModelState.IsValid)
                {
                   var edit = _iCustomerServices.editCustomer(cus);
                    bool edited = await edit;
                    if (edited == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError("Error 404", "Not found");
                return View();
            
            //catch
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            
        }

        // GET: CustomersController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var cus = _iCustomerServices.getCustomerObj(id);
            if (id == null)
            {
                return NotFound();
            }

            return View(cus);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id,int A)
        {
            var temp = _iCustomerServices.GetLstCustomer();
            try
            {
                if (ModelState.IsValid)
                {
                    if (_iCustomerServices.checkIdCustomer(id))
                    {
                        _iCustomerServices.deleteCustomer(id);
                    }

                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
