// Iterator design pattern

using System;
using System.Collections;


// Example -1 
// Iterator interface
public interface IIterator
{
    bool HasNext();
    object Next();
}

// Aggregate interface
public interface IAggregate
{
    IIterator GetIterator();
}

// Concrete Iterator
public class ConcreteIterator : IIterator
{
    private readonly object[] items;
    private int index = 0;

    public ConcreteIterator(object[] items)
    {
        this.items = items;
    }

    public bool HasNext()
    {
        return index < items.Length;
    }

    public object Next()
    {
        if (HasNext())
        {
            return items[index++];
        }
        else
        {
            throw new InvalidOperationException("End of collection reached");
        }
    }
}

// Concrete Aggregate
public class ConcreteAggregate : IAggregate
{
    private readonly object[] items;

    public ConcreteAggregate(object[] items)
    {
        this.items = items;
    }

    public IIterator GetIterator()
    {
        return new ConcreteIterator(items);
    }
}

// Example -2
// Iterator interface
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Aggregate interface
public interface IAggregate<T>
{
    IIterator<T> GetIterator();
}

// Concrete Iterator
public class CustomIterator<T> : IIterator<T>
{
    private readonly List<T> items;
    private int index = 0;

    public CustomIterator(List<T> items)
    {
        this.items = items;
    }

    public bool HasNext()
    {
        return index < items.Count;
    }

    public T Next()
    {
        if (HasNext())
        {
            return items[index++];
        }
        else
        {
            throw new InvalidOperationException("End of collection reached");
        }
    }
}

// Concrete Aggregate
public class CustomAggregate<T> : IAggregate<T>
{
    private readonly List<T> items;

    public CustomAggregate(List<T> items)
    {
        this.items = items;
    }

    public IIterator<T> GetIterator()
    {
        return new CustomIterator<T>(items);
    }
}

// Client
class Program
{
    static void Main()
    {
        // Example -1
        Console.WriteLine("Example 1: ");
        object[] items = { "Item1", "Item2", "Item3", "Item4" };

        IAggregate aggregate = new ConcreteAggregate(items);
        IIterator iterator = aggregate.GetIterator();

        while (iterator.HasNext())
        {
            object item = iterator.Next();
            Console.WriteLine(item);
        }


        // Example -2
        Console.WriteLine("\nExample 2: ");
        List<string> items_2 = new List<string> { "Apple", "Banana", "Orange", "Grapes" };

        IAggregate<string> aggregate2 = new CustomAggregate<string>(items_2);
        IIterator<string> iterator2 = aggregate2.GetIterator();

        while (iterator2.HasNext())
        {
            string item = iterator2.Next();
            Console.WriteLine(item);
        }
    }
}
