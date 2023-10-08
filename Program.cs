using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        // TASK-1

        // a. Greet method

        Console.WriteLine("Calling Greet function without values (default values will be displayed).");
        Greet(); // Calls Greet with default values

        Console.WriteLine("Calling greet function with values.");
        Console.Write("Enter a greeting: ");
        string greeting = Console.ReadLine();
        Console.Write("Enter a name: ");
        string name = Console.ReadLine();
        Greet(greeting, name); // Calls Greet with custom greeting and name


        // b. CalculateArea method
        double area1 = CalculateArea(); // Calls CalculateArea with default values
        Console.WriteLine($"Area with default values: {area1}\n");

        Console.WriteLine("Calculate Area:");
        Console.Write("Enter length: ");
        double length = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter width: ");
        double width = Convert.ToDouble(Console.ReadLine());

        double area2 = CalculateArea(length, width); // Calls CalculateArea with custom length and width
        Console.WriteLine($"Area with custom values: {area2}\n");


        // c. AddNumbers methods
        Console.WriteLine("Add Numbers:");
        Console.Write("Enter the first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());
        int sum1 = AddNumbers(num1, num2); // Calls AddNumbers with two parameters
        Console.WriteLine($"Sum 1: {sum1}\n");

        Console.Write("Enter the third number (optional): ");
        int num3 = Convert.ToInt32(Console.ReadLine());
        int sum2 = AddNumbers(num1, num2); // Calls AddNumbers with three parameters (without optional)
        int sum3 = AddNumbers(num1, num2, num3); // Calls AddNumbers with three parameters (including optional)
        Console.WriteLine($"Sum 2 (AddNumbers with three parameters but w/o optional): {sum2}");
        Console.WriteLine($"Sum 3 (AddNumbers with three parameters with optional): {sum3}\n");


        // d. Book class
        Console.WriteLine("Create a Book (author optional):");
        Console.Write("Enter the book title: ");
        string bookTitle = Console.ReadLine();
        Book book1 = new Book(bookTitle); // Creates a book with default author
        Console.WriteLine($"Book 1 (with default author): {book1.Title}, Author: {book1.Author}\n");

        Console.WriteLine("Create a Book:");
        Console.Write("Enter the book title: ");
        string bookTitle2 = Console.ReadLine();
        Console.Write("Enter the author (optional): ");
        string bookAuthor = Console.ReadLine();
        Book book2 = new Book(bookTitle2, bookAuthor); // Creates a book with specified author
        Console.WriteLine($"Book 2 (with specified author): {book2.Title}, Author: {book2.Author}\n");


        // TASK-2

        // a. Generic Class MyList<T>
        Console.WriteLine("Creating generic Class Mylist instances and calling it's functions.");
        MyList<int> intList = new MyList<int>();
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Remove(3);
        intList.Display();

        MyList<string> stringList = new MyList<string>();
        stringList.Add("Hello");
        stringList.Add("World");
        stringList.Add("oops");
        stringList.Remove("oops");
        stringList.Display();


        // b. Generic method called Swap<T>
        Console.WriteLine("Swap:");
        Console.Write("Enter the first integer: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the second integer: ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Before Swap: a = {a}, b = {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"After Swap: a = {a}, b = {b}\n");


        Console.Write("Enter the first string: ");
        string x = Console.ReadLine();
        Console.Write("Enter the second string: ");
        string y = Console.ReadLine();
        Console.WriteLine($"Before Swap: x = {x}, y = {y}");
        Swap(ref x, ref y);
        Console.WriteLine($"After Swap: x = {x}, y = {y}\n");


        // c. Generic method that computes sum of elements in an array
        int[] intArray = { 1, 2, 3, 4, 5 };
        long[] longArray = { 1L, 2L, 3L, 4L, 5L };
        double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5 };
        Console.WriteLine("Calling generic method to compute the sum of elements(types that support addition) in an array .");
        Console.WriteLine($"Sum of intArray: {Sum<int>(intArray)}");
        Console.WriteLine($"Sum of longArray: {Sum<long>(longArray)}");
        Console.WriteLine($"Sum of doubleArray: {Sum<double>(doubleArray)}\n");


        // d. Student Database System
        Dictionary<int, string> studentDatabase = new Dictionary<int, string>();
        studentDatabase.Add(101, "Alice");
        studentDatabase.Add(102, "Bob");
        studentDatabase.Add(103, "Charlie");
        studentDatabase.Add(104, "David");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. View the student database");
            Console.WriteLine("2. Search for a student by ID");
            Console.WriteLine("3. Update a student's name");
            Console.WriteLine("4. Exit the program");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayStudentDatabase(studentDatabase);
                    break;
                case 2:
                    SearchStudentByID(studentDatabase);
                    break;
                case 3:
                    UpdateStudentName(studentDatabase);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    // TASK-1
    // a. Greet method
    public static void Greet(string greeting = "Hello", string name = "World")
    {
        Console.WriteLine($"{greeting}, {name}!\n");
    }

    // b. CalculateArea method
    public static double CalculateArea(double length = 1.0, double width = 1.0)
    {
        return length * width;
    }

    // c. AddNumbers methods
    public static int AddNumbers(int num1, int num2)
    {
        return num1 + num2;
    }

    public static int AddNumbers(int num1, int num2, int num3 = 0)
    {
        return num1 + num2 + num3;
    }

    // d. Book class
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author = "Unknown")
        {
            Title = title;
            Author = author;
        }
    }


    // TASK-2
    // a. Generic Class MyList<T>
    class MyList<T>
    {
        private List<T> myList = new List<T>();

        public void Add(T item)
        {
            myList.Add(item);
        }

        public void Remove(T item)
        {
            myList.Remove(item);
        }

        public void Display()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
        }
    }

    // b. Generic method called Swap<T>
    static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    // c. Generic method that computes sum of elements in an array
    static T Sum<T>(T[] array) where T : struct, IComparable<T>
    {
        T sum = default(T);
        foreach (T item in array)
        {
            sum = (dynamic)sum + item;
        }
        return sum;
    }

    // d. Student Database System
    static void DisplayStudentDatabase(Dictionary<int, string> studentDatabase)
    {
        Console.WriteLine("\nStudent Database:");
        foreach (var student in studentDatabase)
        {
            Console.WriteLine($"Student ID: {student.Key}, Name: {student.Value}");
        }
    }

    static void SearchStudentByID(Dictionary<int, string> studentDatabase)
    {
        Console.Write("Enter Student ID to search: ");
        int studentID = Convert.ToInt32(Console.ReadLine());
        if (studentDatabase.TryGetValue(studentID, out string name))
        {
            Console.WriteLine($"Student ID: {studentID}, Name: {name}");
        }
        else
        {
            Console.WriteLine("Student ID not found.");
        }
    }

    static void UpdateStudentName(Dictionary<int, string> studentDatabase)
    {
        Console.Write("Enter Student ID to update: ");
        int studentID = Convert.ToInt32(Console.ReadLine());
        if (studentDatabase.ContainsKey(studentID))
        {
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            studentDatabase[studentID] = newName;
            Console.WriteLine("Student name updated successfully.");
        }
        else
        {
            Console.WriteLine("Student ID not found.");
        }
    }
}



