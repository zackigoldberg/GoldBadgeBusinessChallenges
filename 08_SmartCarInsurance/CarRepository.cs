using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SmartCarInsurance
{
    class CarRepository
    {
        List<Car> carList = new List<Car>();
        public bool ReturnTrueFalse(string s)
        {
            if (s == "y" || s == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddCarToList(Car car)
        {
            carList.Add(car);
        } 
        public decimal PremiumCalculator(Car car)
        {
            decimal charge = 45m;
            if (car.StopsAppropriately == true)
            {
                charge += -15m;
            }
            else
            {
                charge += 15m;
            }
            if (car.SwerveDetector == true)
            {
                charge += 25m;
            }
            else
            {
                charge += -5.25m;
            }
            if (car.TailgateDetector == true)
            {
                charge += 25.15m;
            }
            else
            {
                charge += -5.25m;
            }
            if (car.UsesTurnSignalOnTurns == true)
            {
                charge += -25.50m;
            }
            else
            {
                charge += 25.50m;
            }
            if (car.CarMaxSpeed > 80f)
            {
                charge += 15m;
            }
            else
            {
                charge += -5m;
            }
            if (car.AverageCarspeed < 55)
            {
                charge += -10m;
            }
            else
            {
                charge += 10m;
            }
            return charge;
        }
    }
}
