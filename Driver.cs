using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Driver
    {
        // Attributes
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public Location CurrLocation { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<int> Ratings { get; private set; }
        public bool Availability { get; set; }

        private static int nextId = 1;
        public int Id = 1;

        // Constructor
        public Driver(string name, int age, string gender, string address, string phoneNo, Vehicle vehicle)
        {
            Id = nextId;
            nextId++;
            Name = name;
            Age = age;
            Gender = gender;
            Address = address;
            PhoneNo = phoneNo;
            CurrLocation = null;// Initially not known
            Vehicle = vehicle;
            Ratings = new List<int>();// Initially not known
            Availability = false; // Initially not available
        }

        // Functions

        // Update availability status
        public void UpdateAvailability()
        {
            Console.Write("Are you currently available to take a ride? (true/false): ");
            bool inputValid = false;
            while (!inputValid)
            {
                if (bool.TryParse(Console.ReadLine(), out bool newAvailability))
                {
                    Availability = newAvailability;
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
                }
            }
        }

        // Get average rating
        public double GetRating()
        {
            if (Ratings.Count == 0)
            {
                return 0;
            }
            double sum = 0;
            foreach (int rating in Ratings)
            {
                sum += rating;
            }
            return sum / Ratings.Count;
        }

        // Update current location
        public void UpdateLocation()
        {
            Console.Write("Enter the latitude of your new current location: ");
            if (float.TryParse(Console.ReadLine(), out float latitude))
            {
                Console.Write("Enter the longitude of your new current location: ");
                if (float.TryParse(Console.ReadLine(), out float longitude))
                {
                    // Assuming CurrLocation is a valid property of the Driver class
                    CurrLocation = new Location(latitude, longitude);
                }
                else
                {
                    Console.WriteLine("Invalid longitude input. Location not updated.");
                }
            }
            else
            {
                Console.WriteLine("Invalid latitude input. Location not updated.");
            }
        }


    }
}
