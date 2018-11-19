using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenCarResearch
{
    class CarRepository
    {
        List<Car> _carList = new List<Car>();
        //Create
        public void Create(Car car)
        {
            car.CostPerMileOnAverage = ((car.TotalSpentOnRepairs / car.Mileage) + (car.PriceOfGallonOrKilowattHour / car.MilesToGallonOrKilowattHour));
            _carList.Add(car);
        }
        //Read
        public List<Car> ReadCarList()
        {
            return _carList;
        }
        public List<Car> ReadSpecificCarType(CarType cT)
        {
            List<Car> listOfCarType = new List<Car>();
            foreach (Car c in _carList)
            {
                if (c.TypeOfCar == cT)
                {
                    listOfCarType.Add(c);
                }
            }
            return listOfCarType;
        }
        //Update
        public void Update(string carModel, Car car)
        {
            foreach (Car c in _carList)
            {
                if (carModel == c.CarModel)
                {
                    Delete(carModel);
                    Create(car);
                }
            }
        }
        //Delete
        public void Delete(string carModel)
        {
            List<Car> updateList = new List<Car>();
            foreach (Car c in _carList)
            {
                if (carModel != c.CarModel)
                {
                    updateList.Add(c);
                }
            }
            _carList = updateList;
        }
    }
}
