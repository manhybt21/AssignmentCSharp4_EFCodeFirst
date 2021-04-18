using AssignmentCSharp4_EFCodeFirst.Context;
using AssignmentCSharp4_EFCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Controllers
{
    public class AccountsController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public AccountsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Customer acc)
        {
            _databaseContext.Add(acc);
            await _databaseContext.SaveChangesAsync();
            return View();

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Customer customer)
        {
                var findAcount = _databaseContext.Customers.Where(x => x.Password == customer.Password && x.EmailAddress == customer.EmailAddress).FirstOrDefault();
            if (findAcount == null)
            {
                return View();
            }
                else if (findAcount.EmailAddress == customer.EmailAddress || findAcount.Password == customer.Password)
                {
                return RedirectToAction("Index", "ViewProducts");
                }
                else
                {
                return View();
                }
        }
    }
}
