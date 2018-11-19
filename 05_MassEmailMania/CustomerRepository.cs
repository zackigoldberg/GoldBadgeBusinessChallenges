using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_MassEmailMania
{
    class CustomerRepository
    {
        List<Customer> _customerList = new List<Customer>();
        //Create
        public void AddNewCustomer(Customer customer)
        {
            _customerList.Add(customer);
        }
        //Read
        public List<Customer> ReadList()
        {
            return _customerList;
        }
        //Update
        public void UpdateCustomerInfo(string lastName, Customer customer)
        {
            List<Customer> updateList = new List<Customer>();
            var customerToBeUpdated = new Customer();
            foreach (Customer c in _customerList)
            {
                if (c.LastName != lastName)
                {
                    updateList.Add(c);
                }
                else
                {
                    customerToBeUpdated = c;
                }

            }
        }
        //Delete
        public void DeleteCustomerInfo(string lastName)
        {
            List<Customer> updateList = new List<Customer>();
            foreach (Customer c in _customerList)
            {
                if (c.LastName != lastName)
                {
                    updateList.Add(c);
                }
            }
            _customerList = updateList;
        }
        //Sort
        public void SortMyList()
        {
            _customerList.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));
        }
        //Email type
        public string CustomerEmailMessage(CustomerType c)
        {
            if (c == CustomerType.Future)
            {
                return "We would love to have your business, our helicopter insurance rates are the lowest they have every been!";
            }
            else if (c == CustomerType.Present)
            {
                return "Wow, thanks for choosing Komodo! Here is a coupon for a discount on a new insurance product, helicopter insurance";
            }
            else if (c == CustomerType.Past)
            {
                return "Wow, its been a long time, we have a new product offering that you might be interested in, Helicopter insurance, come on back in give it a try!";
            }
            else
                return "We don't know you, but we'd like to, come try our helicopter insurance, its the best in the business!";
        }
        public CustomerType CustomerChooser(int i)
        {
            switch (i)
            {
                case 1:
                    return CustomerType.Future;
                case 2:
                    return CustomerType.Present;
                case 3:
                    return CustomerType.Past;
                default:
                    return CustomerType.Future;


            }
        }
    }
}

