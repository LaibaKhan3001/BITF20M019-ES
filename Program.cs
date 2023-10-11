using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static string connectionString = "Data Source=.;Initial Catalog=AssignmentFive;Integrated Security=True;";

    static void Main(string[] args)
    {
        CreateDatabaseAndTable();
        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Read All Employees");
            Console.WriteLine("2. Add Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Search Employee by ID");
            Console.WriteLine("5. Update Employee");
            Console.WriteLine("6. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ReadAllEmployees();
                    break;
                case 2:
                    AddEmployee();
                    break;
                case 3:
                    DeleteEmployee();
                    break;
                case 4:
                    SearchEmployeeByID();
                    break;
                case 5:
                    UpdateEmployee();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    // Database and table creation

    static void CreateDatabaseAndTable()
    {
        string connectionString = "Data Source=.;Integrated Security=True;";
        string databaseName = "AssignmentFive";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create database
                string createDatabaseQuery = $"CREATE DATABASE {databaseName}";
                SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseQuery, connection);
                createDatabaseCommand.ExecuteNonQuery();

                Console.WriteLine($"Database '{databaseName}' created successfully.");

                // Switch to new database
                connection.ChangeDatabase(databaseName);

                // Create Employees table
                string createTableQuery = @"
                CREATE TABLE Employees
                (
                    ID BIGINT IDENTITY(1,1) PRIMARY KEY,
                    FirstName NVARCHAR(255) NOT NULL,
                    LastName NVARCHAR(255) NOT NULL,
                    Email NVARCHAR(500) NOT NULL,
                    PrimaryPhoneNumber NVARCHAR(11) NOT NULL,
                    SecondaryPhoneNumber NVARCHAR(11),
                    CreatedBy NVARCHAR(100) NOT NULL,
                    CreatedOn DATETIME NOT NULL,
                    ModifiedBy NVARCHAR(100),
                    ModifiedOn DATETIME
                )";
                SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection);
                createTableCommand.ExecuteNonQuery();

                Console.WriteLine("Table 'Employees' created successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }


    // CRUD methods here

    static void ReadAllEmployees()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Employees";
            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("\nList of Employees:");
                Console.WriteLine("------------------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}");
                    Console.WriteLine($"FirstName: {reader["FirstName"]}");
                    Console.WriteLine($"LastName: {reader["LastName"]}");
                    Console.WriteLine($"Email: {reader["Email"]}");
                    Console.WriteLine($"PrimaryPhoneNumber: {reader["PrimaryPhoneNumber"]}");
                    Console.WriteLine($"SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"]}");
                    Console.WriteLine($"CreatedBy: {reader["CreatedBy"]}");
                    Console.WriteLine($"CreatedOn: {reader["CreatedOn"]}");
                    Console.WriteLine($"ModifiedBy: {reader["ModifiedBy"]}");
                    Console.WriteLine($"ModifiedOn: {reader["ModifiedOn"]}");
                    Console.WriteLine("------------------------------------------\n");
                }
            }
        }
    }




    static void AddEmployee()
    {
        Console.Write("\nEnter FirstName: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter LastName: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        Console.Write("Enter PrimaryPhoneNumber: ");
        string primaryPhoneNumber = Console.ReadLine();
        Console.Write("Enter SecondaryPhoneNumber (optional): ");
        string secondaryPhoneNumber = Console.ReadLine();
        Console.Write("Enter CreatedBy: ");
        string createdBy = Console.ReadLine();
        DateTime createdOn = DateTime.Now;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = @"
            INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn)
            VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @SecondaryPhoneNumber, @CreatedBy, @CreatedOn)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
            command.Parameters.AddWithValue("@SecondaryPhoneNumber", string.IsNullOrEmpty(secondaryPhoneNumber) ? DBNull.Value : (object)secondaryPhoneNumber);
            command.Parameters.AddWithValue("@CreatedBy", createdBy);
            command.Parameters.AddWithValue("@CreatedOn", createdOn);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("Employee added successfully.");
            else
                Console.WriteLine("Failed to add employee.");
        }
    }



    static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID to delete: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM Employees WHERE ID = @EmployeeId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeId", employeeId);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nEmployee deleted successfully.\n");
            else
                Console.WriteLine("\nEmployee not found or failed to delete.\n");
        }
    }



    static void SearchEmployeeByID()
    {
        Console.Write("\nEnter Employee ID to search: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Employees WHERE ID = @EmployeeId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeId", employeeId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}");
                    Console.WriteLine($"FirstName: {reader["FirstName"]}");
                    Console.WriteLine($"LastName: {reader["LastName"]}");
                    Console.WriteLine($"Email: {reader["Email"]}");
                    Console.WriteLine($"PrimaryPhoneNumber: {reader["PrimaryPhoneNumber"]}");
                    Console.WriteLine($"SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"]}");
                    Console.WriteLine($"CreatedBy: {reader["CreatedBy"]}");
                    Console.WriteLine($"CreatedOn: {reader["CreatedOn"]}");
                    Console.WriteLine($"ModifiedBy: {reader["ModifiedBy"]}");
                    Console.WriteLine($"ModifiedOn: {reader["ModifiedOn"]}");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
        }
    }




    static void UpdateEmployee()
    {
        Console.Write("\nEnter Employee ID to update: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter FirstName: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter LastName: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        Console.Write("Enter PrimaryPhoneNumber: ");
        string primaryPhoneNumber = Console.ReadLine();
        Console.Write("Enter SecondaryPhoneNumber (optional): ");
        string secondaryPhoneNumber = Console.ReadLine();
        Console.Write("Enter ModifiedBy: ");
        string modifiedBy = Console.ReadLine();
        DateTime modifiedOn = DateTime.Now;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = @"
            UPDATE Employees 
            SET FirstName = @FirstName, LastName = @LastName, Email = @Email, 
                PrimaryPhoneNumber = @PrimaryPhoneNumber, SecondaryPhoneNumber = @SecondaryPhoneNumber, 
                ModifiedBy = @ModifiedBy, ModifiedOn = @ModifiedOn
            WHERE ID = @EmployeeId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeId", employeeId);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
            command.Parameters.AddWithValue("@SecondaryPhoneNumber", string.IsNullOrEmpty(secondaryPhoneNumber) ? DBNull.Value : (object)secondaryPhoneNumber);
            command.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
            command.Parameters.AddWithValue("@ModifiedOn", modifiedOn);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("Employee updated successfully.");
            else
                Console.WriteLine("Employee not found or failed to update.");
        }
    }

}
