using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BarbecueTracking
{
    class Dessert : Booth
    {
        public decimal PopcornCost { get; set; }
        public int TotalPopcornGiven { get; set; }
        public decimal IceCreamCost { get; set; }
        public int TotalIceCreamGiven { get; set; }
        public Dessert()
        {

        }
    }
}
