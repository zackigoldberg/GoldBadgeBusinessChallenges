using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BarbecueTracking
{
    class ProgramUI
    {
        BarbecueRepository _bbqRepo = new BarbecueRepository();
        public void Run()
        {
            int input = 0;
            while (input != 5)
            {
                Console.WriteLine("Welcome to the menu for choosing barbecue tracking, please read the options below as they have recently changed:\n" +
                    "1. Create a new barbecue \n" +
                    "2. Look at all barbecue expenses in a list\n" +
                    "3. Look at the total cost associated with the Burger Booth\n" +
                    "4. Look at the total cost associated with the Ice Cream Booth\n" +
                    "5. Leave this menu");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateBarbecue();
                        break;
                    case 2:
                        ExamineBarbecueList();
                        break;
                    case 3:
                        TotalCostBurgerBooth();
                        break;
                    case 4:
                        CostIceCreamBooth();
                        break;
                    case 5:
                        Console.WriteLine("Thanks for choosing Komodo Barbecue tracking, have a dragon of a day!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid user input... Try again");
                        Console.ReadLine();
                        break;
                }
            }
        }
        //Create
        private void CreateBarbecue()
        {
            // Burger booth
            Burger burger = new Burger();
            Dessert dessert = new Dessert();
            Console.WriteLine("How many Burger's were given out?");
            burger.HamburgerGiven = int.Parse(Console.ReadLine());
            Console.WriteLine("How much did each burger cost?");
            burger.HamburgerCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("How many Hot Dog's were given out?");
            burger.HotDogGiven = int.Parse(Console.ReadLine());
            Console.WriteLine("How much did each hot dog cost?");
            burger.HotDogCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("How many Veggie burgers were given out?");
            burger.VeggieBurgerGiven = int.Parse(Console.ReadLine());
            Console.WriteLine("How much did each Veggie burger cost?");
            burger.VeggieBurgerCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("How much was spent on condiments for this booth (napkins, ketchup, etc)?");
            burger.CondimentCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("How many tickets were collected at the burger booth?");
            burger.TicketsCollected = int.Parse(Console.ReadLine());
            Console.Clear();

            // Ice Cream Booth
            Console.WriteLine("Now let's talk about the Dessert booth.\n" +
                "How many gallons of Ice Cream were consumed?");
            dessert.TotalIceCreamGiven = int.Parse(Console.ReadLine());
            Console.WriteLine("How much did each gallon of ice cream cost?");
            dessert.IceCreamCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("How many bags of popcorn were given out?");
            dessert.TotalPopcornGiven = int.Parse(Console.ReadLine());
            Console.WriteLine("How much did each bag of popcorn cost?");
            dessert.PopcornCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("How much did this booth spend on condiments?");
            dessert.CondimentCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("How many tickets did the dessert booth collect?");
            dessert.TicketsCollected = int.Parse(Console.ReadLine());
            _bbqRepo.CreateNewBooth(dessert, burger);
        }
        //View
        private void ExamineBarbecueList()
        {
            Console.Clear();
            int count = 1;
            foreach (Barbecue b in _bbqRepo.DisplayBooth())
            {
                b.TicketsCollected = _bbqRepo.TicketsCollected(b);
                b.TotalCost = _bbqRepo.TotalBBQCost(b);
                Console.WriteLine($"Barbecue #:{count} \n" +
                    $"Burgers Given: {b.NewBurger.HamburgerGiven} \n" +
                    $"Burger cost/ticket: ${b.NewBurger.HamburgerCost,0:N2} \n" +
                    $"Hot Dogs Given: {b.NewBurger.HotDogGiven} \n" +
                    $"Hot Dogs cost/ticket: ${b.NewBurger.HotDogCost,0:N2} \n" +
                    $"Veggie Burgers given:  {b.NewBurger.VeggieBurgerGiven} \n" +
                    $"Veggie Burgers cost/ticket: ${b.NewBurger.VeggieBurgerCost,0:N2} \n" +
                    $"Burger Booth Tickets collected: {b.NewBurger.TicketsCollected}  \n" +
                    $"Ice Cream given: {b.NewDessert.TotalIceCreamGiven} \n" +
                    $"Ice Cream cost/" +
                    $"gallon: ${b.NewDessert.IceCreamCost,0:N2} \n" +
                    $"Popcorn Given: {b.NewDessert.TotalPopcornGiven} \n" +
                    $"Popcorn cost/bag: {b.NewDessert.PopcornCost,0:N2} \n" +
                    $"Dessert Booth Collected Tickets: {b.NewDessert.TicketsCollected} \n" +
                    $"Total BBQ Cost:{b.TotalCost,0:N2} \n" +
                    $"Total Tickets Collected: {b.TicketsCollected} \n \n \n \n \n");
                Console.WriteLine("Press enter to view the next barbecue.");
                Console.ReadLine();
                Console.Clear();
                count++;
            }
        }
        private void TotalCostBurgerBooth()
        {
            var burger = _bbqRepo.BurgerBoothCost();
            Console.WriteLine($"Hamburger total Cost: ${burger.HamburgerCost,0:N2} \n" +
                $"Hot Dog total Cost: ${burger.HotDogCost,0:N2} \n" +
                $"Veggie Burger total Cost: ${burger.VeggieBurgerCost,0:N2} \n" +
                $"Condiment total Cost: ${burger.CondimentCost,0:N2} \n" +
                $"Total Tickets Collected: {burger.TicketsCollected}\n " +
                $"Total Spent on all Burger booths: {(burger.HamburgerCost + burger.HotDogCost + burger.VeggieBurgerCost + burger.CondimentCost),0:N2}");
        }
        private void CostIceCreamBooth()
        {
            var dessert = _bbqRepo.DessertCost();
            Console.WriteLine($"Ice Cream total Cost: ${dessert.IceCreamCost,0:N2} " +
                $"Popcorn total Cost: ${dessert.PopcornCost,0:N2}" +
                $"Condiment total Cost: ${dessert.CondimentCost,0:N2}" +
                $"Total Tickets CollecteD: {dessert.TicketsCollected}" +
                $"Total spent on all Dessert booths: ${(dessert.IceCreamCost + dessert.PopcornCost + dessert.CondimentCost),0:N2}");
        }
    }
}
