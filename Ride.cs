using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Ride
    {
        // Attributes
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public int Price { get; private set; }
        public Driver Driver { get; private set; }
        public Passenger Passenger { get; private set; }

        // Constructor
        public Ride()
        {
            Price = 0;
            Driver = null;
            Passenger = null;
        }

        // Function to assign a passenger to the ride
        public void AssignPassenger(Passenger passenger)
        {
            Passenger = passenger;
        }

        // Function to assign a driver to the ride based on availability and proximity
        public void AssignDriver(Driver[] availableDrivers)
        {
            if (availableDrivers == null || availableDrivers.Length == 0)
            {
                Console.WriteLine("No available drivers. Ride cannot be assigned.");
                return;
            }

            double minDistance = double.MaxValue;
            Driver closestDriver = null;

            foreach (Driver driver in availableDrivers)
            {
                if (driver.Availability)
                {
                    double distance = CalculateDistance(StartLocation, driver.CurrLocation);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestDriver = driver;
                    }
                }
            }

            if (closestDriver != null)
            {
                Driver = closestDriver;
                closestDriver.Availability = false; // Mark the driver as unavailable
            }
            else
            {
                Console.WriteLine("No available drivers close to the starting location.");
            }
        }

        // Function to set start and end locations of the ride
        public void GetLocations(Location startLocation, Location endLocation)
        {
            StartLocation = startLocation;
            EndLocation = endLocation;
        }

        // Function to calculate the price of the ride
        public void CalculatePrice(string vehicleType)
        {
            double fuelPrice = 300;
            double fuelAverage = 0;
            double commission = 0;
            if (vehicleType == "car")
            {
                fuelAverage =15;
                commission =0.2;
            }
            else if (vehicleType=="bike")
            {
                fuelAverage=50;
                commission=0.05;
            }
            else if(vehicleType=="rickshaw")
            {
                fuelAverage = 35;
                commission = 0.1;
            }
            double distance = CalculateDistance(StartLocation, EndLocation);
            Price = (int)((distance * fuelPrice) / fuelAverage + commission);
        }

        // Helper function to calculate the Euclidean distance between two locations
        private double CalculateDistance(Location location1, Location location2)
        {
            double dx = location1.Latitude - location2.Latitude;
            double dy = location1.Longitude - location2.Longitude;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
