using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SmartCarInsurance
{
    class ProgramUI
    {
        CarRepository _carRepo = new CarRepository();
        public void Run()
        {
            Car car = new Car();
            car.SelfDriving = CarIdentifier();
            if (car.SelfDriving == true)
            {
                Console.WriteLine("Congratulations fellow machine your premium is $50.00");
                car.Premium = 50.00m;
                _carRepo.AddCarToList(car);
                Console.ReadLine();
            }
            else
            {
                car.CarMaxSpeed = CarSpeeder();
                car.AverageCarspeed = CarAverageSpeed();
                car.SwerveDetector = CarSwerving();
                car.StopsAppropriately = CarBlowsStopSign();
                car.TailgateDetector = TailGating();
                _carRepo.AddCarToList(car);

                var premium = _carRepo.PremiumCalculator(car);
                Console.WriteLine($"The new car insurance premium for this vehicle is ${premium, 0:N2}.");
                Console.WriteLine("Have a Komodo safe drive!");
                Console.ReadLine();
            }
        }


        //Car following to closely: Based on sensor data from the forward warning sensors.
        private bool TailGating()
        {
            Console.WriteLine("Have your forward sensors recorded being close to other objects at high speed? (y/n)");
            bool tailGating = _carRepo.ReturnTrueFalse(Console.ReadLine());
            return tailGating;
        }

        //Car not stopping: based on car slowing down to near zero speeds before moving forward.
        private bool CarBlowsStopSign()
        {
            Console.WriteLine("When the car is slowing down does it consistently come to a complete stop? (y/n)");
            bool carStop = _carRepo.ReturnTrueFalse(Console.ReadLine());
            return carStop;
        }

        //Car Swerves: based on sudden steering wheel movements at speeds higher than 30 mph.
        private bool CarSwerving()
        {
            Console.WriteLine("Does the user make sudden adjustments while driving at high speeds? (y/n)");
            bool swerveTest = _carRepo.ReturnTrueFalse(Console.ReadLine());
            return swerveTest;
        }

        //Car Speeding: based on max speed recorded and average mph traveled.
        private float CarSpeeder()
        {
            Console.WriteLine("What is the current maximum speed recorded for your driver?");
            float maxSpeed = float.Parse(Console.ReadLine());
            return maxSpeed;
        }
        private float CarAverageSpeed()
        {
            Console.WriteLine("What is the average speed driven across all drives?");
            var avgSpeed = float.Parse(Console.ReadLine());
            return avgSpeed;
        }
        //Car Identification

        private bool CarIdentifier()
        {
            Console.WriteLine("Are you a self-driving car? (y/n)");
            bool selfDriving = _carRepo.ReturnTrueFalse(Console.ReadLine());
            return selfDriving;
        }

    }
}
