using project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace project1
{
    internal class Program
    {
        static Admin admin = new Admin();
        static void Main(string[] args)
        {
            while (true)
            {
                
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("WELCOME TO MYRIDE");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Book a Ride");
                Console.WriteLine("2. Enter as Driver");
                Console.WriteLine("3. Enter as Admin");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Press 1 to 4 to select an option:");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        BookARide();
                        break;
                    case "2":
                        EnterAsDriver();
                        break;
                    case "3":
                        EnterAsAdmin();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
                
            }
        }
        static void BookARide()
        {
            Console.Clear();
            Console.WriteLine("Book a Ride");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone no: ");
            string passengerPhoneNo;
            do
            {
                passengerPhoneNo = Console.ReadLine();
                if (!IsValidPhoneNumber(passengerPhoneNo))
                {
                    Console.WriteLine("Invalid phone number format. Please enter a valid phone number.");
                }
            } while (!IsValidPhoneNumber(passengerPhoneNo));

            Passenger passenger=new Passenger(name, passengerPhoneNo);
            Driver[] drivers = admin.DriversList.ToArray();
            passenger.BookRide(passenger,drivers);
        }
        
        // Helper function to check if phone number is valid or not
        static bool IsValidPhoneNumber(string phoneNo)
        {
            return Regex.IsMatch(phoneNo, @"^\d{11}$"); // Example: 11-digit phone number
        }



        static void EnterAsDriver()
        {
            Console.Clear();
            Console.WriteLine("Enter as Driver");

            Console.Write("Enter ID: ");
            int driverID;
            if (int.TryParse(Console.ReadLine(), out driverID))
            {
           
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                
                // Check if the driver is registered
                Driver driver = admin.DriversList.FirstOrDefault(d => d.Name == name && d.Id == driverID);
                
                if (driver != null)
                {
                    
                    Console.WriteLine("Hello " + driver.Name + "!");

                    while (true)
                    {
                        Console.WriteLine("Driver Options:");
                        Console.WriteLine("1. Change availability");
                        Console.WriteLine("2. Change Location");
                        Console.WriteLine("3. Exit as Driver");
                        Console.Write("Enter your choice (1-3): ");

                        if (int.TryParse(Console.ReadLine(), out int driverChoice))
                        {
                            switch (driverChoice)
                            {
                                case 1:
                                    driver.UpdateAvailability();
                                    break;
                                case 2:
                                    driver.UpdateLocation();
                                    break;
                                case 3:
                                    Console.WriteLine("Exiting as Driver...");
                                    return; // Return to the main menu
                                default:
                                    Console.WriteLine("Invalid choice. Please try again.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Driver not found or ID and Name do not match. Returning to Main Menu.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Returning to Main Menu.");
            }
        }



        static void EnterAsAdmin()
        {
            Console.Clear();
            Console.WriteLine("Enter as Admin");

            while (true)
            {
                Console.WriteLine("Admin Options:");
                Console.WriteLine("1. Add Driver");
                Console.WriteLine("2. Remove Driver");
                Console.WriteLine("3. Update Driver");
                Console.WriteLine("4. Search Driver");
                Console.WriteLine("5. Exit as Admin");
                Console.Write("Enter your choice (1-5): ");

                if (int.TryParse(Console.ReadLine(), out int adminChoice))
                {
                    switch (adminChoice)
                    {
                        case 1:
                            admin.AddDriver();

                            break;
                        case 2:
                            admin.RemoveDriver();
                            break;
                        case 3:
                            admin.UpdateDriver();
                            break;
                        case 4:
                            admin.SearchDriver();
                            break;
                        case 5:
                            Console.WriteLine("Exiting as Admin...");
                            return; // Return to the main menu
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}


