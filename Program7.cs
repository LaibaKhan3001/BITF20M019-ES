// Decorator design pattern


using System;


// Example - 1
// Component interface
interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Concrete Component
class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double GetCost()
    {
        return 2.0;
    }
}

// Decorator
abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public virtual string GetDescription()
    {
        return coffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return coffee.GetCost();
    }
}

// Concrete Decorators
class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return $"{coffee.GetDescription()}, Milk";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 0.5;
    }
}

class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return $"{coffee.GetDescription()}, Sugar";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 0.2;
    }
}

// Example - 2
// Component interface
interface IWindow
{
    void Draw();
}

// Concrete Component
class SimpleWindow : IWindow
{
    public void Draw()
    {
        Console.WriteLine("Drawing a simple window");
    }
}

// Decorator
abstract class WindowDecorator : IWindow
{
    protected IWindow window;

    public WindowDecorator(IWindow window)
    {
        this.window = window;
    }

    public virtual void Draw()
    {
        window.Draw();
    }
}

// Concrete Decorators
class BorderDecorator : WindowDecorator
{
    public BorderDecorator(IWindow window) : base(window) { }

    public override void Draw()
    {
        base.Draw();
        Console.WriteLine("Adding border to the window");
    }
}

class ScrollBarDecorator : WindowDecorator
{
    public ScrollBarDecorator(IWindow window) : base(window) { }

    public override void Draw()
    {
        base.Draw();
        Console.WriteLine("Adding scroll bar to the window");
    }
}




class Program
{
    static void Main()
    {
        // Example - 1
        // Order a simple coffee
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: ${coffee.GetCost()}");

        // Decorate the coffee with milk
        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: ${coffee.GetCost()}");

        // Decorate the coffee with sugar
        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: ${coffee.GetCost()}");
        Console.WriteLine();

        // Example - 2
        // Create a simple window
        IWindow window = new SimpleWindow();
        window.Draw();

        Console.WriteLine();

        // Decorate the window with a border
        IWindow decoratedWindow = new BorderDecorator(window);
        decoratedWindow.Draw();

        Console.WriteLine();

        // Decorate the window with a scroll bar
        decoratedWindow = new ScrollBarDecorator(window);
        decoratedWindow.Draw();

        Console.WriteLine();

        // Decorate the window with both a border and a scroll bar
        decoratedWindow = new BorderDecorator(new ScrollBarDecorator(window));
        decoratedWindow.Draw();
    }
}
