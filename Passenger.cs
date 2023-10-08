using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace project1
{
    internal class Passenger
    {
        // Attributes
        public string Name { get; set; }
        public string PhoneNo { get; set; }

        // Constructor
        public Passenger(string name, string phoneNo)
        {
            Name = name;
            PhoneNo = phoneNo;
        }

        // Functions

        // Book a new ride
        public void BookRide(Passenger passenger, Driver[] drivers)
        {
            
            Console.Write("Enter Start Location (latitude,longitude): ");
            if (float.TryParse(Console.ReadLine(), out float startLat) && float.TryParse(Console.ReadLine(), out float startLon))
            {
                Location startLocation = new Location(startLat, startLon);
               
                Console.Write("Enter End Location (latitude,longitude): ");
                if (float.TryParse(Console.ReadLine(), out float endLat) && float.TryParse(Console.ReadLine(), out float endLon))
                {
                    Location endLocation = new Location(endLat, endLon);

                    string rideType;
                    bool validInput = false;
                    do
                    {
                        Console.Write("Enter Ride Type (car, bike, or rickshaw): ");
                        rideType = Console.ReadLine().ToLower(); 
                        if (rideType == "car" || rideType == "bike" || rideType == "rickshaw")
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ride type. Please enter 'car,' 'bike,' or 'rickshaw.'");
                        }
                    }
                    while (!validInput);

                    // Now, the variable "rideType" contains the valid ride type.

                    Ride ride = new Ride();
                    ride.GetLocations(startLocation, endLocation);
                    ride.CalculatePrice(rideType);
                    ride.AssignPassenger(passenger);
                    ride.AssignDriver(drivers);
                    Console.WriteLine("Price for this ride is: " + ride.Price);

                    Console.Write("Enter 'Y' if you want to Book the ride, enter 'N' if you want to cancel operation: ");
                    string bookChoice = Console.ReadLine();

                    if (bookChoice.ToLower() == "y")
                    {
                        Console.WriteLine("Happy Travel!");
                        int rating= passenger.GiveRating();
                        ride.Driver.Ratings.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("Ride booking canceled.");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid End Location. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Start Location. Please try again.");
            }

        }

        // Give a rating for the current ride
        public int GiveRating()
        {
            while (true)
            {
                Console.Write("Please give a rating from 1 to 5 for the current ride: ");
                if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
                {
                    return rating;
                }
                else
                {
                    Console.WriteLine("Invalid rating. Please enter a number from 1 to 5.");
                }
            }
        }
    }
}
