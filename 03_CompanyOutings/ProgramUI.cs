using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CompanyOutings
{
    class ProgramUI
    {
        public OutingRepository _outing = new OutingRepository(); public void Run()
        {

            bool menuOperator = true;
            while (menuOperator == true)
            {
                Console.WriteLine("Welcome to the company outing expense tracking service, what would you like to do today?\n" +
                "1. Display a list of all outings\n" +
                "2. Add a new outing\n" +
                "3. Calculators");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        DisplayList();
                        break;
                    case 2:
                        AddOuting();
                        break;
                    case 3:
                        Calculations();
                        break;
                    default:
                        Console.WriteLine("Invalid Input please try again!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void Calculations()
        {
            int input = 0;
            while (input != 6)
            {
                Console.WriteLine("What charges do you want to look at?\n" +
                    "1. Total charges\n" +
                    "2. Golf charges\n" +
                    "3. Bowling charges\n" +
                    "4. Amusement Park charges\n" +
                    "5. Concert charges\n" +
                    "6. Return to Main Menu");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        decimal totalCost = 0.00m;
                        totalCost = _outing.GetTotalCostForAllOutings();
                        Console.WriteLine($"The total cost of all events is ${totalCost}");
                        Console.ReadLine();
                        break;
                    case 2:
                        totalCost = _outing.GetCostByOutingType("Golf");
                        Console.WriteLine($"The total cost of Golfing events is ${totalCost}");
                        Console.ReadLine();
                        break;
                    case 3:
                        totalCost = _outing.GetCostByOutingType("Bowling");
                        Console.WriteLine($"The total cost of Bowling events is ${totalCost}");
                        Console.ReadLine();
                        break;
                    case 4:
                        totalCost = _outing.GetCostByOutingType("Amusement Park");
                        Console.WriteLine($"The total cost of Amusment Park adventures is ${totalCost}");
                        Console.ReadLine();
                        break;
                    case 5:
                        totalCost = _outing.GetCostByOutingType("Concert");
                        Console.WriteLine($"The total cost of Concerts is ${totalCost}");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("That is an invalid input please try again!");
                        break;
                }
            }
        }

        private void AddOuting()
        {
            int input = 0;
            while (input != 5)
            {
                Console.WriteLine("What type of event are you dealing with?\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n" +
                    "5. Return to main menu");
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        GolfOuting();
                        Console.Clear();
                        break;
                    case 2:
                        BowlingOuting();
                        Console.Clear();
                        break;
                    case 3:
                        AmusementParkOuting();
                        Console.Clear();
                        break;
                    case 4:
                        ConcertOuting();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                }

            }
        }

        private void BowlingOuting()
        {
            Bowling bowling = new Bowling();
            bowling.TypeOfEvent = "Bowling";
            Console.WriteLine("How many people attended this event?");
            bowling.NumberOfPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("What was the total event cost?");
            bowling.EventCost = decimal.Parse(Console.ReadLine());
            bowling.CostPerPerson = bowling.EventCost / bowling.NumberOfPeople;
            Console.WriteLine($"This event cost ${bowling.CostPerPerson}");
            Console.WriteLine("When was this event?");
            bowling.DateOfEvent = DateTime.Parse(Console.ReadLine());
            _outing.AddToOutingList(bowling);
        }

        private void AmusementParkOuting()
        {
            AmusementPark amusementPark = new AmusementPark();
            amusementPark.TypeOfEvent = "Amusement Park";
            Console.WriteLine("How many people attended this event?");
            amusementPark.NumberOfPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("What was the total event cost?");
            amusementPark.EventCost = decimal.Parse(Console.ReadLine());
            amusementPark.CostPerPerson = amusementPark.EventCost / amusementPark.NumberOfPeople;
            Console.WriteLine($"This event cost ${amusementPark.CostPerPerson}");
            Console.WriteLine("When was this event?");
            amusementPark.DateOfEvent = DateTime.Parse(Console.ReadLine());
            _outing.AddToOutingList(amusementPark);
        }

        private void ConcertOuting()
        {
            Concert concert = new Concert();
            concert.TypeOfEvent = "Amusement Park";
            Console.WriteLine("How many people attended this event?");
            concert.NumberOfPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("What was the total event cost?");
            concert.EventCost = decimal.Parse(Console.ReadLine());
            concert.CostPerPerson = concert.EventCost / concert.NumberOfPeople;
            Console.WriteLine($"This event cost ${concert.CostPerPerson}");
            Console.WriteLine("When was this event?");
            concert.DateOfEvent = DateTime.Parse(Console.ReadLine());
            _outing.AddToOutingList(concert);
        }

        private void GolfOuting()
        {
            Golf golf = new Golf();
            golf.TypeOfEvent = "Golf";
            Console.WriteLine("How many people attended this event?");
            golf.NumberOfPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("What was the total event cost?");
            golf.EventCost = decimal.Parse(Console.ReadLine());
            golf.CostPerPerson = golf.EventCost / golf.NumberOfPeople;
            Console.WriteLine($"This event cost ${golf.CostPerPerson}");
            Console.WriteLine("When was this event?");
            golf.DateOfEvent = DateTime.Parse(Console.ReadLine());
            _outing.AddToOutingList(golf);
        }

        private void DisplayList()
        {
            Console.WriteLine(" People attended:            Type of Event:              Event Cost:         Cost per Person:        Date of event:");
            foreach (Outing o in _outing.DisplayOutingList())
            {
                Console.WriteLine($" {o.NumberOfPeople}   {o.TypeOfEvent}    ${o.EventCost}   ${o.CostPerPerson}   {o.DateOfEvent}");
            }
        }
    }
}
