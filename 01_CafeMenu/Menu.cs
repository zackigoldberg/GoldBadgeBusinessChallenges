using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeMenu
{
    public class Menu
    {
        public int DeleteItem { get; set; }
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string IngredientList { get; set; }
        public decimal MealPrice { get; set; }
        public Menu(int mealNumber, string mealName, string mealDescription, string ingredientList, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            IngredientList = ingredientList;
            MealPrice = mealPrice;
        }
        public Menu()
        {

        }
    }
}
