using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SmartCarInsurance
{
    class Car
    {
        public float CarMaxSpeed { get; set; }
        public float AverageCarspeed { get; set; }
        public bool StopsAppropriately { get; set; }
        public bool SwerveDetector { get; set; }
        public bool TailgateDetector { get; set; }
        public bool UsesTurnSignalOnTurns { get; set; }
        public bool SelfDriving { get; set; }
        public decimal Premium { get; set; }
        public Car()
        {

        }
    }
}
