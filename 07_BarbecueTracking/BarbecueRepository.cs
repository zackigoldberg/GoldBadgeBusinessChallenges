using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BarbecueTracking
{
    class BarbecueRepository
    {
        List<Barbecue> _barbecueList = new List<Barbecue>();
        //Create new booth\
        public void CreateNewBooth(Dessert d, Burger b)
        {
            Barbecue barbecue = new Barbecue();
            barbecue.NewBurger = b;
            barbecue.NewDessert = d;
            _barbecueList.Add(barbecue);
        }
        //View existing boothes
        public List<Barbecue> DisplayBooth()
        {
            return _barbecueList;
        }
        public List<Burger> DisplayBurgerBooth()
        {
            List<Burger> burgerList = new List<Burger>();
            foreach (Barbecue bBQ in _barbecueList)
            {
                burgerList.Add(bBQ.NewBurger);
            }
            return burgerList;
        }
        public List<Dessert> DisplayDessertBooth()
        {
            List<Dessert> dessertList = new List<Dessert>();
            foreach (Barbecue b in _barbecueList)
            {
                dessertList.Add(b.NewDessert);
            }
            return dessertList;
        }
        //Calculate Burger Booth cost 
        public Burger BurgerBoothCost()
        {
            List<Burger> burgerList = new List<Burger>();
            Burger burger = new Burger();
            foreach (Barbecue bbq in _barbecueList)
            {
                burgerList.Add(bbq.NewBurger);
            }
            foreach (Burger b in burgerList)
            {
                burger.HamburgerCost += (b.HamburgerCost * b.HamburgerGiven);
            }
            foreach (Burger b in burgerList)
            {
                burger.HotDogCost += (b.HotDogCost * b.HotDogGiven);
            }
            foreach (Burger b in burgerList)
            {
                burger.VeggieBurgerCost += (b.VeggieBurgerCost * b.VeggieBurgerGiven);
            }
            foreach (Burger b in burgerList)
            {
                burger.CondimentCost += b.CondimentCost;
            }
            foreach (Burger b in burgerList)
            {
                burger.TicketsCollected += b.TicketsCollected;
            }
            return burger;
        }
        //Calculate Dessert Booth cost 
        public Dessert DessertCost()
        {
            List<Dessert> dessertList = new List<Dessert>();
            Dessert dessert = new Dessert();
            foreach (Barbecue b in _barbecueList)
            {
                dessertList.Add(b.NewDessert);
            }
            foreach (Dessert d in dessertList)
            {
                dessert.IceCreamCost += (d.IceCreamCost * d.TotalIceCreamGiven);
            }
            foreach (Dessert d in dessertList)
            {
                dessert.PopcornCost += (d.PopcornCost * d.TotalPopcornGiven);
            }
            foreach (Dessert d in dessertList)
            {
                dessert.CondimentCost += d.CondimentCost;
            }
            foreach (Dessert d in dessertList)
            {
                dessert.TicketsCollected += d.TicketsCollected;
            }
            return dessert;
        }
        //Calculate Total cost of BBQ
        public int TicketsCollected(Barbecue bBQ)
        {
            bBQ.TicketsCollected = bBQ.NewBurger.TicketsCollected + bBQ.NewDessert.TicketsCollected;
            return bBQ.TicketsCollected;
        }
        public decimal TotalBBQCost(Barbecue bBQ)
        {
            bBQ.TotalCost = ((bBQ.NewBurger.HamburgerCost * bBQ.NewBurger.HamburgerGiven) + (bBQ.NewBurger.HotDogCost * bBQ.NewBurger.HotDogGiven) + (bBQ.NewBurger.VeggieBurgerCost * bBQ.NewBurger.VeggieBurgerGiven) + (bBQ.NewDessert.IceCreamCost * bBQ.NewDessert.TotalIceCreamGiven) + (bBQ.NewDessert.TotalPopcornGiven * bBQ.NewDessert.PopcornCost));
            return bBQ.TotalCost;
        }
    }
}
