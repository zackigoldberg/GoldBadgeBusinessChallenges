using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeMenu
{
    class ProgramUI
    {
        private int navigation;
        MenuRepository _menuRepository = new MenuRepository();
        public void Run()
        {
            while (navigation != 4)
            {
                Console.WriteLine("Welcome to the menu item entry portal, please choose from the following options \n\n\t" +
                    "1. Create new Menu item \n\t" +
                    "2. Delete existing Menu item \n\t" +
                    "3. List all current menu items\n\t" +
                    "4. Exit Menu");
                navigation = int.Parse(Console.ReadLine());
                switch (navigation)
                {
                    case 1:
                        NewMenuItem();
                        break;
                    case 2:
                        DeleteMenuItem();
                        break;
                    case 3:
                        ListMenuItem();
                        break;
                    case 4:
                        Console.WriteLine("Thanks for using the new item entry portal, please come again.");
                        break;
                    default:
                        Console.WriteLine("Incorrect input, please try again.");
                        break;

                }
            }
        }
        private void NewMenuItem()
        {
            Menu menu = new Menu();
            Console.WriteLine("What is the item's number?");
            menu.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the name of the item you would like to create?");
            menu.MealName = Console.ReadLine();

            Console.WriteLine($"How would you describe the {menu.MealName}?");
            menu.MealDescription = Console.ReadLine();

            Console.WriteLine("What ingredients are in this item? (Please leave a comma between each item)");
            menu.IngredientList = Console.ReadLine();

            Console.WriteLine($"How much should you charge for {menu.MealName}");
            menu.MealPrice = decimal.Parse(Console.ReadLine());

            _menuRepository.AddMenuToList(menu);
            Console.Clear();
        }

        private void DeleteMenuItem()
        {
            ListMenuItem();
            Console.WriteLine("To delete an item please use the Deletion number provided on the left of each item.");
            _menuRepository.DeleteItem(int.Parse(Console.ReadLine()));
        }
        private void ListMenuItem()
        {
            int count = 0;
            Console.WriteLine($" Deletion number: Item Number:  Name of Item:    Ingredient List:         Price:             Description:");
            foreach (Menu menu in _menuRepository.DisplayMenu())
            {
                Console.WriteLine($" -{count}-            {menu.MealNumber}               {menu.MealName}            {menu.IngredientList}               ${menu.MealPrice}         {menu.MealDescription}");
                count++;
            }
}
