// Adapter design pattern

using System;

// Example - 1
// Target interface
interface ITarget
{
    void Request();
}

// Adaptee (existing class to be adapted)
class AdapteeA
{
    public void SpecificRequest()
    {
        Console.WriteLine("AdapteeA's specific request");
    }
}

// Adapter class
class ObjectAdapterA : ITarget
{
    private AdapteeA adaptee;

    public ObjectAdapterA(AdapteeA adaptee)
    {
        this.adaptee = adaptee;
    }

    public void Request()
    {
        adaptee.SpecificRequest();
    }
}

// Example - 2
// Target interface
interface ITargetB
{
    void Request();
}

// Adaptee (existing class to be adapted)
class AdapteeB
{
    public void SpecificRequest()
    {
        Console.WriteLine("AdapteeB's specific request");
    }
}

// Adapter class
class ClassAdapterB : AdapteeB, ITargetB
{
    public void Request()
    {
        SpecificRequest(); // Calls the adapted method from the base class
    }
}

class Program
{
    static void Main()
    {
        // Example - 1
        AdapteeA adaptee = new AdapteeA();
        ITarget target = new ObjectAdapterA(adaptee);

        target.Request(); // Calls the adapted method through the adapter
        Console.WriteLine();

        // Example - 2
        ITargetB targetB = new ClassAdapterB();

        targetB.Request(); // Calls the adapted method through the adapter
    }
}
