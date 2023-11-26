// Template Method design pattern

using System;


// Example - 1
abstract class CaffeineBeverage
{
    // Template method
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    // These methods will be implemented by the subclasses
    public abstract void Brew();
    public abstract void AddCondiments();

    // Common methods
    public void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    public void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }
}

class Coffee : CaffeineBeverage
{
    public override void Brew()
    {
        Console.WriteLine("Brewing coffee grounds");
    }

    public override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk");
    }
}

class Tea : CaffeineBeverage
{
    public override void Brew()
    {
        Console.WriteLine("Steeping the tea");
    }

    public override void AddCondiments()
    {
        Console.WriteLine("Adding lemon");
    }
}


// Example - 2
abstract class Document
{
    // Template method
    public void GenerateDocument()
    {
        AddHeader();
        AddBody();
        AddFooter();
    }

    // These methods will be implemented by the subclasses
    protected abstract void AddHeader();
    protected abstract void AddBody();
    protected abstract void AddFooter();
}

class HTMLDocument : Document
{
    protected override void AddHeader()
    {
        Console.WriteLine("<html><head><title>HTML Document</title></head><body>");
    }

    protected override void AddBody()
    {
        Console.WriteLine("<p>This is an HTML document.</p>");
    }

    protected override void AddFooter()
    {
        Console.WriteLine("</body></html>");
    }
}

class PlainTextDocument : Document
{
    protected override void AddHeader()
    {
        Console.WriteLine("Plain Text Document");
        Console.WriteLine("-------------------");
    }

    protected override void AddBody()
    {
        Console.WriteLine("This is a plain text document.");
    }

    protected override void AddFooter()
    {
        // No footer for plain text
    }
}



class Program
{
    static void Main()
    {

        // Example - 1
        Console.WriteLine("Example 1:");
        CaffeineBeverage coffee = new Coffee();
        CaffeineBeverage tea = new Tea();

        Console.WriteLine("Making Coffee...");
        coffee.PrepareRecipe();

        Console.WriteLine("\nMaking Tea...");
        tea.PrepareRecipe();


        // Example - 2
        Console.WriteLine("\nExample 2:");
        Document htmlDocument = new HTMLDocument();
        Document plainTextDocument = new PlainTextDocument();

        Console.WriteLine("Generating HTML Document...");
        htmlDocument.GenerateDocument();

        Console.WriteLine("\nGenerating Plain Text Document...");
        plainTextDocument.GenerateDocument();
    }
}
