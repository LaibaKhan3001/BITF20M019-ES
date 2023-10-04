using System;

class Program
{
    static void Main()
    {
        // Task-1
        ConcatenateNames();
        

        // Task-2
        // Call this method to get the last 5 characters
        ExtractLastFiveCharacters();


        // Task-3
        string message = GetTemperatureAndCity();

        // Display the message
        Console.WriteLine(message);

        
        // Task-4
        InitializeAndPrintArray();

        
        // Task-5a
        IterateArrayWithForLoop();
        
        
        // Task5-b
        IterateArrayWithForeachLoop();
        

        // Task-6
        int sum = CalculateSumWithDoWhile();
        Console.WriteLine("Sum of test scores: " + sum);
        

        // Task-7
        int max = FindMaxValueWithWhile();
        Console.WriteLine("Maximum value in the array: " + max);
        

        // Task-8
        ReverseArrayInPlace();
       

        // Task-9a
        int x = 42;
        int y = UnboxInteger(BoxInteger(x));

        Console.WriteLine("Value of 'y': " + y);
         
     
        // Task-9b
        double doubleValue = 3.14159;
        double unboxedValue = UnboxDouble(BoxDouble(doubleValue));

        Console.WriteLine("Value of 'unboxedValue': " + unboxedValue);
    

        // Task-10a
        int[] numbers = { 2, 4, 6, 8, 10 };
        foreach (int num in numbers)
        {
            SquareAndDisplay(num);
        }
        

        // Task-10b
        List<object> mixedList = new List<object>();

        // Add elements of different types to the list
        mixedList.Add(42);           // Add an integer
        mixedList.Add(3.14159);      // Add a double
        mixedList.Add('A');          // Add a char

        DisplayElementsAndTypes(mixedList);

       
        // Task-11a
        dynamic myVariable = 42;
        DisplayDynamicValueAndType(myVariable);

        myVariable = "Hello, Dynamic!";
        DisplayDynamicValueAndType(myVariable);
        

        // Task-11b
        dynamic myVariable2 = 42;
        DisplayDynamicType(myVariable2);

        myVariable2 = 3.14159;
        DisplayDynamicType(myVariable2);

        myVariable2 = DateTime.Now;
        DisplayDynamicType(myVariable2);

        myVariable2 = "Dynamic Variable";
        DisplayDynamicType(myVariable2);
        
    }


    // Task-1
    // Function to concatenate the first name and last name
    static void ConcatenateNames()
    {
        // Ask the user for their first name
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        // Ask the user for their last name
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        // Concatenating
        string fullName = firstName + " " + lastName;

        // Display the full name
        Console.WriteLine("Your full name is: " + fullName);
    }


    // Task-2
    static void ExtractLastFiveCharacters()
    {
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();

        if (sentence.Length >= 5)
        {
            string lastFiveCharacters = sentence.Substring(sentence.Length - 5);

            // Display the last 5 characters
            Console.WriteLine("Last 5 characters: " + lastFiveCharacters);
        }
        else
        {
            Console.WriteLine("Senetence has less than 5 chararcters which are "+ sentence);
        }
    }


    // Task-3
    static string GetTemperatureAndCity()
    {
        // Ask the user for the current temperature
        Console.Write("Enter the current temperature in degrees Celsius: ");
        double temperature;
        if (double.TryParse(Console.ReadLine(), out temperature))
        {
            // Ask the user for the name of their city
            Console.Write("Enter the name of your city: ");
            string city = Console.ReadLine();

            // Create and format the message using string.Format
            return string.Format("The temperature in {0} is {1} degrees Celsius.", city, temperature);
        }
        else
        {
            return "Invalid input. Please enter a valid temperature.";
        }
    }


    // Task-4
    static void InitializeAndPrintArray()
    {
        int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
        Console.WriteLine("Elements of the array:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }


    // Task-5a
    static void IterateArrayWithForLoop()
    {
        string[] fruits = { "Apple", "Banana", "Orange", "Grapes" };

        Console.WriteLine("Iterating through the 'fruits' array using a for loop:");
        for (int i = 0; i < fruits.Length; i++)
        {
            Console.WriteLine(fruits[i]);
        }
    }


    // Task-5b
    static void IterateArrayWithForeachLoop()
    {
        string[] colors = { "Red", "Blue", "Green", "Yellow" };
        Console.WriteLine("Iterating through the 'colors' array using a foreach loop and displaying colors separated by commas:");
        foreach (string color in colors)
        {
            Console.Write(color + ", ");
        }
        Console.WriteLine(); // Move to a new line after printing all elements
    }


    // Task-6
    static int CalculateSumWithDoWhile()
    {
        int[] scores = { 85, 92, 78, 95, 88, 70, 89, 92, 76, 81 };
        int sum = 0;
        int index = 0;

        // Use a do-while loop to iterate through the array
        do
        {
            sum += scores[index];
            index++;
        } while (index < scores.Length);

        return sum;
    }


    // Task-7
    static int FindMaxValueWithWhile()
    {
        int[] values = { 42, 15, 78, 96, 21, 64, 32, 88, 5 };
        if (values.Length == 0)
        {
            Console.WriteLine("The array is empty.");
        }

        int max = values[0]; // Initialize max with the first element
        int index = 1;

        // Use a while loop to iterate through the array
        while (index < values.Length)
        {
            if (values[index] > max)
            {
                max = values[index]; // Update max if a larger value is found
            }
            index++;
        }

        return max;
    }


    // Task-8
    static void ReverseArrayInPlace()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        Console.WriteLine("Original array:");
        PrintArray(numbers);

        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)
        {
            // Swap the elements at the left and right indices
            int temp = numbers[left];
            numbers[left] = numbers[right];
            numbers[right] = temp;

            // Move the indices towards each other
            left++;
            right--;
        }
        Console.WriteLine("Reversed array:");
        PrintArray(numbers);
    }
    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }


    // Task-9a
    // Function to box an integer value
    static object BoxInteger(int value)
    {
        return value;
    }
    // Function to unbox an object to an integer
    static int UnboxInteger(object obj)
    {
        return (int)obj;
    }


    // Task-9b
    // Function to box a double value
    static object BoxDouble(double value)
    {
        return value;
    }
    // Function to unbox an object to a double
    static double UnboxDouble(object obj)
    {
        return (double)obj;
    }


    // Task-10a
    // Function to square an integer, display both the original integer and its squared value
    static void SquareAndDisplay(int num)
    {
        // i. Boxing the current integer value
        object boxedObject = num;

        // ii. Unboxing the boxed object and store it in a new integer variable
        int unboxedInt = (int)boxedObject;

        // iii. Calculate the square of the unboxed integer
        int squaredValue = unboxedInt * unboxedInt;

        // iv. Display both the original integer and its squared value
        Console.WriteLine($"Original Integer: {unboxedInt}, Squared Value: {squaredValue}");

    }


    // Task-10b
    // Function to display elements and their types in a generic List
    static void DisplayElementsAndTypes(List<object> list)
    {
        Console.WriteLine("Elements and their types:");

        foreach (object item in list)
        {
            // Display the element
            Console.WriteLine($"Element: {item}");

            // Check the type of the element
            if (item is int)
            {
                int intValue = (int)item;
                Console.WriteLine($"Type: Integer, Value: {intValue}");
            }
            else if (item is double)
            {
                double doubleValue = (double)item;
                Console.WriteLine($"Type: Double, Value: {doubleValue}");
            }
            else if (item is char)
            {
                char charValue = (char)item;
                Console.WriteLine($"Type: Char, Value: {charValue}");
            }
        }
    }

    // Task-11a
    // Function to display the value and type of a dynamic variable
    static void DisplayDynamicValueAndType(dynamic variable)
    {
        Console.WriteLine("Value: " + variable);
        
    }


    // Task-11b
    // Function to display the type of a dynamic variable
    static void DisplayDynamicType(dynamic variable)
    {
        Console.WriteLine("Value: " + variable);
        Console.WriteLine("Type: " + variable.GetType());
    }

}

