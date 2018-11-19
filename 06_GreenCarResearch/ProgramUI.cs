using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenCarResearch
{
    class ProgramUI
    {
        CarRepository _carRepo = new CarRepository();
        public void Run()
        {
            int input = 0;
            while (input != 5)
            {
                Console.Clear();

                Console.WriteLine("What action would you like to take:\n" +
                    "1. Create new data on a Car\n" +
                    "2. Read information about current cars\n" +
                    "3. Update car information\n" +
                    "4. Delete car information\n" +
                    "5. Exit Menu");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateNewCar();
                        break;
                    case 2:
                        ReadExistingCarList();
                        break;
                    case 3:
                        UpdateExistingCar();
                        break;
                    case 4:
                        DeleteExistingCar();
                        break;
                    case 5:
                        Console.WriteLine("Thanks for using the Komodo Electric car research program, please come again!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid input please try again");
                        break;
                }
            }
        }
        // Create Methods
        private void CreateNewCar()
        {
            Car newCar = new Car();
            Console.Write("What is the Car Make:");
            newCar.CarMake = Console.ReadLine();

            Console.Write("What is the Car Model:");
            newCar.CarModel = Console.ReadLine();

            Console.Write("What type of car are we dealing with (Electric, Hybrid, or Gas):");
            newCar.TypeOfCar = TypeOfCar();

            Console.Write("How many miles are on the vehicle:");
            newCar.Mileage = int.Parse(Console.ReadLine());

            Console.Write("How much has been spent repairing the example vehicle: $");
            newCar.TotalSpentOnRepairs = decimal.Parse(Console.ReadLine());

            Console.Write("How fuel efficient is the vehicle in Miles per Gallon or Miles per Kilowatt hours:");
            newCar.MilesToGallonOrKilowattHour = decimal.Parse(Console.ReadLine());

            Console.Write("What is the cost of the fuel type per unit at this time:$");
            newCar.PriceOfGallonOrKilowattHour = decimal.Parse(Console.ReadLine());
            _carRepo.Create(newCar);
            Console.Clear();
        }
        private CarType TypeOfCar()
        {
            string carTypeAsString = Console.ReadLine();
            if (carTypeAsString == "Electric" || carTypeAsString == "electric")
            {
                return CarType.Electric;
            }
            else if (carTypeAsString == "Hybrid" || carTypeAsString == "hybrid")
            {
                return CarType.Hybrid;
            }
            else if (carTypeAsString == "Gas" || carTypeAsString == "gas")
            {
                return CarType.Gas;
            }
            else
            {
                Console.WriteLine("That was an invalid input, defaulting to a gas powered vehicle");
                return CarType.Gas;
            }
        }
        // Read Methods
        private void ReadExistingCarList()
        {
            int input = 0;
            while (input != 5)
            {
                Console.WriteLine("What Car Type would you like to examine more closely: \n" +
                    "1. Electric\n" +
                    "2. Gas\n" +
                    "3. Hybrid\n" +
                    "4. All Cars\n" +
                    "5. Exit Menu");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        DisplayList(_carRepo.ReadSpecificCarType(CarType.Electric));
                        break;
                    case 2:
                        DisplayList(_carRepo.ReadSpecificCarType(CarType.Gas));
                        break;
                    case 3:
                        DisplayList(_carRepo.ReadSpecificCarType(CarType.Hybrid));
                        break;
                    case 4:
                        DisplayList(_carRepo.ReadCarList());
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid input pleas try again!");
                        break;
                }
            }
        }
        private void DisplayList(List<Car> list)
        {
            Console.WriteLine($" {"Car Make",-15} {"Car Model",-15} {"Car Type",-10} {"Car Mileage",-15} {"Car MPG/MPKW",-15} {"Average Cost per Mile",-15}");
            foreach (Car c in list)
            {
                Console.WriteLine($" {c.CarMake,-15} {c.CarModel,-15} {c.TypeOfCar,-10} {c.Mileage,-15} {c.MilesToGallonOrKilowattHour,-15} ${c.CostPerMileOnAverage,-15:N2}");
            }
            Console.WriteLine("\t\t\n\n\n\nPress Enter to return to the menu");
            Console.ReadLine();
            Console.Clear();
        }
        // Update Methods
        private void UpdateExistingCar()
        {
            Car updateCar = new Car();
            Console.Write("What is the make of the car you want to Update:");
            updateCar.CarMake = Console.ReadLine();
            Console.Write("What is the Car Model:");
            updateCar.CarModel = Console.ReadLine();

            Console.Write("What type of car are we dealing with (Electric, Hybrid, or Gas):");
            updateCar.TypeOfCar = TypeOfCar();

            Console.Write("How many miles are on the vehicle:");
            updateCar.Mileage = int.Parse(Console.ReadLine());

            Console.WriteLine("How much has been spent repairing the example vehicle: $");
            updateCar.TotalSpentOnRepairs = decimal.Parse(Console.ReadLine());

            Console.WriteLine("How fuel efficient is the vehicle in Miles per Gallon or Miles per Kilowatt hours:");
            updateCar.MilesToGallonOrKilowattHour = decimal.Parse(Console.ReadLine());

            Console.WriteLine("What is the cost of the fuel type per unit at this time:$");
            updateCar.PriceOfGallonOrKilowattHour = decimal.Parse(Console.ReadLine());

            _carRepo.Update(updateCar.CarModel, updateCar);
            Console.Clear();
        }
        // Deletion Methods
        private void DeleteExistingCar()
        {
            Console.Write("Which car Model do you want to delete:");
            _carRepo.Delete(Console.ReadLine());
            Console.Clear();
        }
        
    }
}
