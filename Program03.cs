// Chain of Responsibility design pattern

using System;


// Example - 1
// Handler interface
public abstract class Approver
{
    protected Approver successor;

    public void SetSuccessor(Approver successor)
    {
        this.successor = successor;
    }

    public abstract void ProcessRequest(Purchase purchase);
}

// Concrete Handlers
public class Manager : Approver
{
    public override void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount <= 1000)
        {
            Console.WriteLine($"{nameof(Manager)} approves purchase request #{purchase.Number}");
        }
        else if (successor != null)
        {
            successor.ProcessRequest(purchase);
        }
    }
}

public class Director : Approver
{
    public override void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount <= 5000)
        {
            Console.WriteLine($"{nameof(Director)} approves purchase request #{purchase.Number}");
        }
        else if (successor != null)
        {
            successor.ProcessRequest(purchase);
        }
    }
}

public class VicePresident : Approver
{
    public override void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount <= 10000)
        {
            Console.WriteLine($"{nameof(VicePresident)} approves purchase request #{purchase.Number}");
        }
        else if (successor != null)
        {
            successor.ProcessRequest(purchase);
        }
    }
}

// Request class
public class Purchase
{
    public int Number { get; }
    public double Amount { get; }

    public Purchase(int number, double amount)
    {
        Number = number;
        Amount = amount;
    }
}

// Example - 2
// Handler interface
public abstract class Logger
{
    protected Logger successor;

    public void SetSuccessor(Logger successor)
    {
        this.successor = successor;
    }

    public abstract void LogMessage(string message, LogLevel level);
}

// Concrete Handlers
public class ConsoleLogger : Logger
{
    public override void LogMessage(string message, LogLevel level)
    {
        if (level == LogLevel.Info)
        {
            Console.WriteLine($"Console: {message}");
        }
        else if (successor != null)
        {
            successor.LogMessage(message, level);
        }
    }
}

public class FileLogger : Logger
{
    public override void LogMessage(string message, LogLevel level)
    {
        if (level == LogLevel.Warning)
        {
            Console.WriteLine($"File: {message}");
        }
        else if (successor != null)
        {
            successor.LogMessage(message, level);
        }
    }
}

public class EmailLogger : Logger
{
    public override void LogMessage(string message, LogLevel level)
    {
        if (level == LogLevel.Error)
        {
            Console.WriteLine($"Email: {message}");
        }
        else if (successor != null)
        {
            successor.LogMessage(message, level);
        }
    }
}

// Log levels
public enum LogLevel
{
    Info,
    Warning,
    Error
}


// Client
class Program
{
    static void Main()
    {
        // Example - 1
        Console.WriteLine("Example 1: ");
        Approver manager = new Manager();
        Approver director = new Director();
        Approver vp = new VicePresident();

        manager.SetSuccessor(director);
        director.SetSuccessor(vp);

        Purchase purchase1 = new Purchase(1, 800);
        Purchase purchase2 = new Purchase(2, 2500);
        Purchase purchase3 = new Purchase(3, 12000);

        manager.ProcessRequest(purchase1);
        manager.ProcessRequest(purchase2);
        manager.ProcessRequest(purchase3);


        // Example - 2
        Console.WriteLine("\nExample 2: ");
        Logger consoleLogger = new ConsoleLogger();
        Logger fileLogger = new FileLogger();
        Logger emailLogger = new EmailLogger();

        consoleLogger.SetSuccessor(fileLogger);
        fileLogger.SetSuccessor(emailLogger);

        consoleLogger.LogMessage("This is an informational message.", LogLevel.Info);
        consoleLogger.LogMessage("This is a warning message.", LogLevel.Warning);
        consoleLogger.LogMessage("This is an error message.", LogLevel.Error);

    }
}
