// Strategy design pattern

using System;


// Example - 1
// Strategy interface
public interface IPaymentStrategy
{
    void Pay(int amount);
}

// Concrete Strategies
public class CreditCardPayment : IPaymentStrategy
{
    private string cardNumber;
    private string name;

    public CreditCardPayment(string cardNumber, string name)
    {
        this.cardNumber = cardNumber;
        this.name = name;
    }

    public void Pay(int amount)
    {
        Console.WriteLine($"Paid {amount:C} using Credit Card ({cardNumber}, {name})");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    private string email;

    public PayPalPayment(string email)
    {
        this.email = email;
    }

    public void Pay(int amount)
    {
        Console.WriteLine($"Paid {amount:C} using PayPal ({email})");
    }
}

// Context
public class ShoppingCart
{
    private IPaymentStrategy paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        this.paymentStrategy = paymentStrategy;
    }

    public void Checkout(int amount)
    {
        paymentStrategy.Pay(amount);
    }
}

// Example - 2
// Strategy interface
public interface ISortStrategy
{
    void Sort(int[] array);
}

// Concrete Strategies
public class BubbleSort : ISortStrategy
{
    public void Sort(int[] array)
    {
        Console.WriteLine("Sorting using Bubble Sort");
        // Implement Bubble Sort logic
    }
}

public class QuickSort : ISortStrategy
{
    public void Sort(int[] array)
    {
        Console.WriteLine("Sorting using Quick Sort");
        // Implement Quick Sort logic
    }
}

// Context
public class SortContext
{
    private ISortStrategy sortStrategy;

    public void SetSortStrategy(ISortStrategy sortStrategy)
    {
        this.sortStrategy = sortStrategy;
    }

    public void PerformSort(int[] array)
    {
        sortStrategy.Sort(array);
    }
}



// Client
class Program
{
    static void Main()
    {
        // Example - 1
        Console.WriteLine("Example 1:");
        ShoppingCart cart = new ShoppingCart();

        // Using Credit Card payment strategy
        cart.SetPaymentStrategy(new CreditCardPayment("1234-5678-9101-1121", "John Doe"));
        cart.Checkout(100);

        // Using PayPal payment strategy
        cart.SetPaymentStrategy(new PayPalPayment("john.doe@example.com"));
        cart.Checkout(50);

        // Example - 2
        Console.WriteLine("\nExample 2:");
        SortContext context = new SortContext();

        int[] array1 = { 5, 2, 8, 1, 7 };
        int[] array2 = { 10, 4, 6, 3, 9 };

        // Using Bubble Sort strategy
        context.SetSortStrategy(new BubbleSort());
        context.PerformSort(array1);

        // Using Quick Sort strategy
        context.SetSortStrategy(new QuickSort());
        context.PerformSort(array2);

        
    }
}
