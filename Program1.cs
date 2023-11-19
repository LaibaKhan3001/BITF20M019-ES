// Singleton design pattern



using System;

// EXAMPLE # 1
public class Singleton
{
    private static Singleton instance;

    // Private constructor to prevent instantiation from outside
    private Singleton() { }

    // Public method to get the instance of the singleton class
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    // Other methods or properties of the class
    public void DisplayMessage()
    {
        Console.WriteLine("Hello, I am a Singleton!");
    }
}


// EXAMPLE # 2
public class ThreadSafeSingleton
{
    private static ThreadSafeSingleton instance;
    private static readonly object lockObject = new object();

    // Private constructor to prevent instantiation from outside
    private ThreadSafeSingleton() { }

    // Public method to get the instance of the singleton class
    public static ThreadSafeSingleton Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new ThreadSafeSingleton();
                }
            }
            return instance;
        }
    }

    // Other methods or properties of the class
    public void DisplayMessage()
    {
        Console.WriteLine("Hello, I am a Thread-Safe Singleton!");
    }
}


class Program
{
    static void Main()
    {
        // EXAMPLE # 1
        Console.WriteLine("Class singleton");
        // Access the Singleton instance
        Singleton singleton = Singleton.Instance;

        // Use the instance
        singleton.DisplayMessage();

        // Attempting to create another instance will still return the same instance
        Singleton anotherInstance = Singleton.Instance;
        Console.WriteLine("Attempting to create another instance still returns the same instance?");
        Console.WriteLine(singleton == anotherInstance);  // Output: True

        // EXAMPLE # 2
        Console.WriteLine("\nClass ThreadSafeSingleton");
        // Access the Thread-Safe Singleton instance
        ThreadSafeSingleton instance_0ne = ThreadSafeSingleton.Instance;

        // Use the instance
        instance_0ne.DisplayMessage();

        // Attempting to create another instance will still return the same instance
        ThreadSafeSingleton instance_Two = ThreadSafeSingleton.Instance;
        Console.WriteLine("Attempting to create another instance still returns the same instance?"); 
        Console.WriteLine(instance_0ne == instance_Two);  // Output: True
    }
}
