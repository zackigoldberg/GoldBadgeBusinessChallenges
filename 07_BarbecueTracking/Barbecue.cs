using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BarbecueTracking
{
    class Barbecue
    {
        public Burger NewBurger = new Burger();
        public Dessert NewDessert = new Dessert();
        public decimal TotalCost { get; set; }
        public int TicketsCollected { get; set; }
        public Barbecue()
        {

        }
    }
}
