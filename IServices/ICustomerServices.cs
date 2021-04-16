using AssignmentCSharp4_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.IServices
{
    interface ICustomerServices
    {
        List<Customer> GetLstCustomer();
        Customer findId(int customerId);
        void addCustomer(Customer customer);
        Task<bool> editCustomer(Customer customer);
        string deleteCustomer(int customerId);
        bool checkIdCustomer(int customerId);
        Customer getCustomerObj(int customerId);
    }
}
