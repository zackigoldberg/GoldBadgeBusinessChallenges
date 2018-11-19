using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_MassEmailMania
{
    enum CustomerType {Past, Present, Future}
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType  CustomerType { get; set; }
        public string Email { get; set; }
        public Customer()
        {

        }
    }
}
