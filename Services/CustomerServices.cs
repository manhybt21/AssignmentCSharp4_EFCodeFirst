using AssignmentCSharp4_EFCodeFirst.Context;
using AssignmentCSharp4_EFCodeFirst.IServices;
using AssignmentCSharp4_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Services
{
    public class CustomerServices: ICustomerServices
    {
        private readonly DatabaseContext _context;
        private List<Customer> _lstCustomer;
        public CustomerServices(DatabaseContext context)
        {

            _lstCustomer = new List<Customer>();
            _context = context;
            GetLstCustomer();
        }
        public List<Customer> GetLstCustomer()
        {
            _lstCustomer = _context.Customers.ToList();
            return _lstCustomer;
        }
        public void addCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChangesAsync();
        }
        public async Task<bool> editCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }
            var cus =await _context.Customers.FindAsync(customer.Id);
            cus.Name = customer.Name;
            cus.PhoneNumber = customer.PhoneNumber;
            cus.Address = customer.Address;
            cus.EmailAddress = customer.EmailAddress;
            cus.Password = customer.Password;
            _context.Customers.Update(cus);
            await _context.SaveChangesAsync();
            return true;
        }
        public string deleteCustomer(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChangesAsync();
            }
            return "Xoá Thành Công";
        }
        public Customer findId(int customerId)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == customerId);
        }
        public bool checkIdCustomer(int customerId)
        {
            return _lstCustomer.Any(x => x.Id == customerId);
        }
        public Customer getCustomerObj(int customerId)
        {
            return _lstCustomer.Where(x => x.Id == customerId).FirstOrDefault();
        }
    }
}
