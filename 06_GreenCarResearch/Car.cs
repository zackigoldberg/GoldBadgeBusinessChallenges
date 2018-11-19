using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenCarResearch
{
    public enum CarType { Gas, Electric, Hybrid }
    class Car
    {
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public CarType TypeOfCar { get; set; }
        public int Mileage { get; set; }
        public decimal TotalSpentOnRepairs { get; set; }
        public decimal CostPerMileOnAverage { get; set; }
        public decimal MilesToGallonOrKilowattHour { get; set; }
        public decimal PriceOfGallonOrKilowattHour { get; set; }
        public Car()
        {

        }

    }
}
