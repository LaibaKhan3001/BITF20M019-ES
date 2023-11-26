// Observer design pattern

using System;
using System.Collections.Generic;


// Example - 1
// Subject (Observable)
public class Stock
{
    private string symbol;
    private double price;
    private List<IInvestor> investors = new List<IInvestor>();

    public Stock(string symbol, double price)
    {
        this.symbol = symbol;
        this.price = price;
    }

    public void Attach(IInvestor investor)
    {
        investors.Add(investor);
    }

    public void Detach(IInvestor investor)
    {
        investors.Remove(investor);
    }

    public void Notify()
    {
        foreach (var investor in investors)
        {
            investor.Update(this);
        }
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (price != value)
            {
                price = value;
                Notify();
            }
        }
    }

    public string Symbol => symbol;
}

// Observer
public interface IInvestor
{
    void Update(Stock stock);
}

// Concrete Observers
public class Investor : IInvestor
{
    private string name;

    public Investor(string name)
    {
        this.name = name;
    }

    public void Update(Stock stock)
    {
        Console.WriteLine($"Notified {name} of {stock.Symbol}'s change to {stock.Price:C}");
    }
}


// Example - 2

// Subject (Observable)
public class NewsAgency
{
    private List<INewsObserver> observers = new List<INewsObserver>();
    private string news;

    public void Attach(INewsObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(INewsObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(news);
        }
    }

    public string News
    {
        get { return news; }
        set
        {
            if (news != value)
            {
                news = value;
                Notify();
            }
        }
    }
}

// Observer
public interface INewsObserver
{
    void Update(string news);
}

// Concrete Observers
public class NewsReader : INewsObserver
{
    private string name;

    public NewsReader(string name)
    {
        this.name = name;
    }

    public void Update(string news)
    {
        Console.WriteLine($"{name} received news: {news}");
    }
}


// Client
class Program
{
    static void Main()
    {
        // Example - 1
        Console.WriteLine("Example 1 :");
        Stock stock = new Stock("ABC", 100.00);

        IInvestor investor1 = new Investor("Investor 1");
        IInvestor investor2 = new Investor("Investor 2");

        stock.Attach(investor1);
        stock.Attach(investor2);

        stock.Price = 95.00;


        // Example - 2
        Console.WriteLine("\nExample 2 :");
        NewsAgency newsAgency = new NewsAgency();

        INewsObserver reader1 = new NewsReader("Reader 1");
        INewsObserver reader2 = new NewsReader("Reader 2");

        newsAgency.Attach(reader1);
        newsAgency.Attach(reader2);

        newsAgency.News = "Breaking News: Important Event Happened!";

        
    }
}
