using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Vehicle
    {
        // Attributes
        public string Type { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        // Constructor
        public Vehicle(string type, string model, string licensePlate)
        {
            Type = type;
            Model = model;
            LicensePlate = licensePlate;
        }
    }
}
 