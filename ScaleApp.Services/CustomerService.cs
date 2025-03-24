using ScaleApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleApp.Services
{
    public class CustomerService(CustomerRepository customerRepository)
    {
        private CustomerRepository _customerRepository = customerRepository;
    }
}
