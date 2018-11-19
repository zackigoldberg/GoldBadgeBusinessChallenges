using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_DoorIdBadges
{
    class BadgeRepository
    {
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        List<string> listDoor = new List<string>();
        public Dictionary<int, List<string>> DoorList()
        {
            listDoor.Add("1a");
            listDoor.Add("");
            _badgeDictionary.Add(1, listDoor);
            return _badgeDictionary;
        }
        //Creates a new badge
        public void CreateNewBadge(int badgeID, List<string> listOfDoors)
        {
            _badgeDictionary.Add(badgeID, listOfDoors);
        }
        //Update an existing badge
        public void UpdateBadge(int key, List<string> valueList)
        {
            _badgeDictionary[key] = valueList;
        }
        //Delete a badge
        public void DeleteDoorsFromBadge(int key)
        {
            _badgeDictionary.Remove(key);
        }
        //Display all badges
        public Dictionary<int, List<string>> MasterBadgeList()
        {
            return _badgeDictionary;
        }
    }
}
