using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BarbecueTracking
{
    class Burger : Booth
    {
        public decimal HamburgerCost { get; set; }
        public int HamburgerGiven { get; set; }
        public decimal VeggieBurgerCost { get; set; }
        public int VeggieBurgerGiven { get; set; }
        public decimal HotDogCost { get; set; }
        public int HotDogGiven { get; set; }
        public Burger()
        {

        }
    }
}
