using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace project1
{
    internal class Admin
    {
        // Attribute
        public List<Driver> DriversList { get; set; }

        // Constructor
        public Admin()
        {
            DriversList = new List<Driver>();
        }

        // Function to add a new driver to the driver's list
        public void AddDriver()
        {
            Console.WriteLine("Adding a new driver...");
            Console.Write("Enter driver's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter driver's age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                Console.Write("Enter driver's gender: ");
                string gender = Console.ReadLine();

                Console.Write("Enter driver's address: ");
                string address = Console.ReadLine();

                Console.Write("Enter driver's phone number (digits only): ");
                string phoneNo = null;
                do
                {
                    phoneNo = Console.ReadLine();
                    if (!IsValidPhoneNumber(phoneNo))
                    {
                        Console.WriteLine("Invalid phone number format. Please enter a valid phone number.");
                    }
                } while (!IsValidPhoneNumber(phoneNo));

                string vehicleType;

                do
                {
                    Console.Write("Enter driver's Vehicle Type (car, bike, or rickshaw): ");
                    vehicleType = Console.ReadLine().ToLower();

                    if (!IsValidVehicleType(vehicleType))
                    {
                        Console.WriteLine("Invalid vehicle type. Please enter 'car,' 'bike,' or 'rickshaw.'");
                    }
                }
                while (!IsValidVehicleType(vehicleType));

                // Now, the variable "vehicleType" contains the valid vehicle type.

                Console.Write("Enter driver's vehicle model: ");
                string vehicleModel = Console.ReadLine();

                Console.Write("Enter driver's vehicle license plate: ");
                string licensePlate = Console.ReadLine();

                // Create a new driver object
                Driver newDriver = new Driver(name, age, gender, address, phoneNo, new Vehicle(vehicleType, vehicleModel, licensePlate));

                // Add the driver to the list
                DriversList.Add(newDriver);

                Console.WriteLine("Driver added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid age input. Driver not added.");
            }
        }

        // Helper function to check if phone number is valid or not
        static bool IsValidPhoneNumber(string phoneNo)
        {
            return Regex.IsMatch(phoneNo, @"^\d{11}$"); // Example: 11-digit phone number
        }



        // Function to update an existing driver
        public void UpdateDriver()
        {
            Console.WriteLine("Updating an existing driver...");
            Console.Write("Enter driver's ID to update: ");
            int driverIdToUpdate;
            if (!int.TryParse(Console.ReadLine(), out driverIdToUpdate))
            {
                Console.WriteLine("Invalid driver ID input. Driver not updated.");
                return;
            }

            Driver driverToUpdate = DriversList.FirstOrDefault(driver => driver.Id == driverIdToUpdate);
            if (driverToUpdate != null)
            {
                Console.WriteLine($"-------------Driver with ID {driverIdToUpdate} exists-------------");

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    driverToUpdate.Name = name;
                }

                Console.Write("Enter Age: ");
                int age;
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    driverToUpdate.Age = age;
                }

                Console.Write("Enter Gender: ");
                string gender = Console.ReadLine();
                if (!string.IsNullOrEmpty(gender))
                {
                    driverToUpdate.Gender = gender;
                }

                Console.Write("Enter Address: ");
                string address = Console.ReadLine();
                if (!string.IsNullOrEmpty(address))
                {
                    driverToUpdate.Address = address;
                }

                Console.Write("Enter Vehicle Type: ");
                string vehicleType = Console.ReadLine();
                if (!string.IsNullOrEmpty(vehicleType))
                {
                    driverToUpdate.Vehicle.Type = vehicleType;
                }

                Console.Write("Enter Vehicle Model: ");
                string vehicleModel = Console.ReadLine();
                if (!string.IsNullOrEmpty(vehicleModel))
                {
                    driverToUpdate.Vehicle.Model = vehicleModel;
                }

                Console.Write("Enter Vehicle License Plate: ");
                string licensePlate = Console.ReadLine();
                if (!string.IsNullOrEmpty(licensePlate))
                {
                    driverToUpdate.Vehicle.LicensePlate = licensePlate;
                }

                Console.WriteLine("Driver information updated successfully!");
            }
            else
            {
                Console.WriteLine($"Driver with ID {driverIdToUpdate} not found.");
            }
        }


        // Function to remove a driver
        public void RemoveDriver()
        {
            Console.WriteLine("Removing a driver...");
            Console.Write("Enter driver's ID to remove: ");
            int idToRemove = int.Parse(Console.ReadLine());

            Driver driverToRemove = DriversList.FirstOrDefault(driver => driver.Id == idToRemove);
            if (driverToRemove != null)
            {
                DriversList.Remove(driverToRemove);
                Console.WriteLine("Driver removed successfully!");
            }
            else
            {
                Console.WriteLine("Driver with ID " + idToRemove + " not found.");
            }
        }


        // Function to search for drivers based on search parameters
        public void SearchDriver()
        {
            Console.WriteLine("Enter search parameters:");
            Console.Write("Driver ID: ");
            int searchID = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Address: ");
            string searchAddress = Console.ReadLine();
            Console.Write("Vehicle type: ");
            string searchVehicleType = Console.ReadLine();
            Console.Write("Vehicle Model: ");
            string vehicleModel = Console.ReadLine();
            Console.Write("Enter driver's vehicle license plate: ");
            string searchLicensePlate = Console.ReadLine();

            var searchResults = DriversList.Where(driver =>
                (searchID == 0 || driver.Id == searchID)&&
                (string.IsNullOrEmpty(name) || driver.Name.Contains(name)) &&
                (age == 0 || driver.Age == age) &&
                (string.IsNullOrEmpty(gender) || driver.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(searchAddress) || driver.Address == searchAddress) &&
                (string.IsNullOrWhiteSpace(searchVehicleType) || driver.Vehicle.Type == searchVehicleType)&&
                (string.IsNullOrEmpty(vehicleModel) || driver.Vehicle.Model.Contains(vehicleModel)) && 
                (string.IsNullOrWhiteSpace(searchLicensePlate) || driver.Vehicle.LicensePlate == searchLicensePlate)
            );

            if (searchResults.Any())
            {
                Console.WriteLine("Search Results:");
                Console.WriteLine("Name\tAge\tGender\tV.type\tV.Model\tV.License");
                foreach (var driver in searchResults)
                {
                    Console.WriteLine($"{driver.Name}\t{driver.Age}\t{driver.Gender}\t{driver.Vehicle.Type}\t{driver.Vehicle.Model}\t{driver.Vehicle.LicensePlate}");
                }
            }
            else
            {
                Console.WriteLine("No drivers found matching the search criteria.");
            }
        }


        // Helper function to check the validity of driver's vehicle
        static bool IsValidVehicleType(string input)
        {
            string[] validTypes = { "car", "bike", "rickshaw" };
            return validTypes.Contains(input.ToLower());
        }
    }
}
