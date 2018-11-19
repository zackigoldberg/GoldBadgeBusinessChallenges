using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeMenu
{
   public class MenuRepository
    {
        List<Menu> _menu = new List<Menu>();
        public void AddMenuToList(Menu menuItem)
        {
            _menu.Add(menuItem);
        }
        public void DeleteItem(int count)
        {
            _menu.RemoveAt(count);
        }
        public List<Menu> DisplayMenu()
        {
            return _menu;
        }
    }
}
