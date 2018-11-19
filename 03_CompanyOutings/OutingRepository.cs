using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CompanyOutings
{
    class OutingRepository
    {
        private List<Outing> _outings = new List<Outing>();
        public void AddToOutingList(Outing outing)
        {
            _outings.Add(outing);
        }
        public List<Outing> DisplayOutingList()
        {
            return _outings;
        }

        public decimal GetTotalCostForAllOutings()
        {
            var total = 0.0m;

            foreach (var outing in _outings)
            {
                total += outing.EventCost;
            }

            return total;

        }

        public decimal GetCostByOutingType(string type)  //consider taking in a string of a type
        {
            var total = 0.0m;
            //logic that totals by type

            foreach (var outing in _outings)
            {
                //conditional logic here
                if (outing.TypeOfEvent == type)
                    total += outing.EventCost;
            }

            return total;
        }
    }
}
s