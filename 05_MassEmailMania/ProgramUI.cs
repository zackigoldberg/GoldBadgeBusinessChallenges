using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_MassEmailMania
{
    class ProgramUI
    {
        CustomerRepository _customer = new CustomerRepository();
        public void Run()
        {
            int input = 0;
            while (input != 6)
            {
                Console.WriteLine("What would you like to do? \n" +
                    "1. Create new Customer\n" +
                    "2. Update existing Customer\n" +
                    "3. Current customer List\n" +
                    "4. Delete an existing Customer\n" +
                    "5. Send emails\n" +
                    "6. Exit menu");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateNewUser();
                        break;
                    case 2:
                        UpdateExistingUser();
                        break;
                    case 3:
                        ReadExistingUserData();
                        break;
                    case 4:
                        DeleteExistingUser();
                        break;
                    case 5:
                        Console.WriteLine("You broke the internet, good job.");
                        break;
                    case 6:
                        Console.WriteLine("Mission accomplished, go Komodo!");
                        break;
                    default:
                        Console.WriteLine("Invalid user input please try again later...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // Create Methods
        private void CreateNewUser()
        {
            Customer customer = new Customer();
            Console.WriteLine("What is the customer's First Name?");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("What is the customer's Last Name?");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("What type of customer are we dealing with?");
            customer.CustomerType = CustomerChooserMenu();

            customer.Email = _customer.CustomerEmailMessage(customer.CustomerType);
            _customer.AddNewCustomer(customer);
            Console.Clear();
        }
        private CustomerType CustomerChooserMenu()
        {

            Console.WriteLine("1. New Customer\n" +
                "2. Existing Customer\n" +
                "3. Past Customer");
            int input = int.Parse(Console.ReadLine());
            return _customer.CustomerChooser(input);
        }
        
        // Read Methods
        private void ReadExistingUserData()
        {
            _customer.SortMyList();
            Console.WriteLine($" {"FirstName:",-15} {"LastName:",-15} {"Type:",-15} {"Email:",-15}");
            foreach (Customer c in _customer.ReadList())
            {
                Console.WriteLine($" {c.FirstName,-14} {c.LastName,-14} {c.CustomerType,-14} {c.Email,-14}");
            }
            Console.ReadLine();
            Console.Clear();
        }
        // Update Methods
        private void UpdateExistingUser()
        {
            Customer customer = new Customer();
            Console.WriteLine("What is the last name of the user you would like to edit?");
            string customerLastName = Console.ReadLine();

            Console.WriteLine("What is the customer's First Name?");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("What is the customer's Last Name?");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("What type of customer are we dealing with?");
            customer.CustomerType = CustomerChooserMenu();

            customer.Email = _customer.CustomerEmailMessage(customer.CustomerType);

            _customer.UpdateCustomerInfo(customerLastName, customer);
            Console.Clear();
        }
        // Delete Methods
        private void DeleteExistingUser()
        {
            Console.WriteLine("What is the Last name of the customer to be deleted?");
            string customerLastName = Console.ReadLine();
            _customer.DeleteCustomerInfo(customerLastName);
            Console.Clear();
        }
    }
}
