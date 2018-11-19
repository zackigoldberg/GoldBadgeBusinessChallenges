using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_DoorIdBadges
{
    class ProgramUI
    {
        BadgeRepository _badge = new BadgeRepository();
        public void Run()
        {
            int input = 0;
            while (input != 5)
            {
                Console.WriteLine("What action would you like to perform\n" +
                    "1. Add New Badge\n" +
                    "2. Update existing badge \n" +
                    "3. Delete doors from existing badge \n" +
                    "4. List of all badges\n" +
                    "5. Exit the menu");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddNewBadge();
                        break;
                    case 2:
                        UpdateExistingBadge();
                        break;
                    case 3:
                        DeleteDoorsOnBadge();
                        break;
                    case 4:
                        ListAllBadges();
                        break;
                    case 5:
                        Console.WriteLine("Thanks for using the badge program, have a great day!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine(value: "Not a valid user input, please try again!");
                        break;


                }
            }
        }
        private void ListAllBadges()
        {
            Console.WriteLine("{0,-4} {1,20} \n", "BadgeID:", "Door Access:");
            foreach (KeyValuePair<int, List<string>> kVP in _badge.MasterBadgeList())
            {
                Console.Write($"{kVP.Key}              ");
                foreach (string s in kVP.Value)
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            }
        }
        private void DeleteDoorsOnBadge()
        {
            Console.WriteLine("Please enter the key you wish to delete all doors from:");
            int key = int.Parse(Console.ReadLine());
            _badge.DeleteDoorsFromBadge(key);
            Console.WriteLine($"Successfully deleted doors from Badge Id:{key}");
        }
        private void UpdateExistingBadge()
        {
            Console.WriteLine("Please enter the key you wish to update:");
            int key = int.Parse(Console.ReadLine());
            var doorList = GetDoorList();
            _badge.UpdateBadge(key, doorList);
        }
        private void AddNewBadge()
        {
            Badge newBadge = new Badge();
            Console.WriteLine("What is the badge Id number?");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            newBadge.DoorList = GetDoorList();
            _badge.CreateNewBadge(newBadge.BadgeID, newBadge.DoorList);
        }
        public List<string> GetDoorList()
        {
            List<string> doorList = new List<string>();
            Console.WriteLine("Below please enter one door at a time a list of doors, when ready to leave this menu type: leave");
            var inputAsString = "";
            while (inputAsString != "leave")
            {
                inputAsString = Console.ReadLine();
                if (inputAsString != "leave")
                {
                    doorList.Add(inputAsString);
                }
            }
            Console.Clear();
            return doorList;
        }
    }
}
