// Composite design pattern
using System;
using System.Collections.Generic;


// Example - 1
// Component interface
interface IComponent
{
    void Display(int depth);
}

// Leaf class
class Leaf : IComponent
{
    private string name;

    public Leaf(string name)
    {
        this.name = name;
    }

    public void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + " " + name);
    }
}

// Composite class
class Composite : IComponent
{
    private List<IComponent> children = new List<IComponent>();

    public void Add(IComponent component)
    {
        children.Add(component);
    }

    public void Remove(IComponent component)
    {
        children.Remove(component);
    }

    public void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + " Composite");

        foreach (var child in children)
        {
            child.Display(depth + 2);
        }
    }
}

// Example - 2
// Component interface
interface IGraphic
{
    void Draw();
}

// Leaf classes
class Circle : IGraphic
{
    public void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

class Square : IGraphic
{
    public void Draw()
    {
        Console.WriteLine("Drawing Square");
    }
}

// Composite class
class CompositeGraphic : IGraphic
{
    private List<IGraphic> graphics = new List<IGraphic>();

    public void Add(IGraphic graphic)
    {
        graphics.Add(graphic);
    }

    public void Remove(IGraphic graphic)
    {
        graphics.Remove(graphic);
    }

    public void Draw()
    {
        foreach (var graphic in graphics)
        {
            graphic.Draw();
        }
    }
}


class Program
{
    static void Main()
    {
        // Example - 1
        // Create a simple composite structure
        var root = new Composite();
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        var composite = new Composite();
        composite.Add(new Leaf("Leaf C"));
        composite.Add(new Leaf("Leaf D"));

        root.Add(composite);

        // Display the structure
        root.Display(1);
        Console.WriteLine();


        // Example - 2
        // Create a composite of graphics
        var composite2 = new CompositeGraphic();
        composite2.Add(new Circle());
        composite2.Add(new Square());

        // Create some individual graphics
        var circle = new Circle();
        var square = new Square();

        // Add the individual graphics to the composite
        composite2.Add(circle);
        composite2.Add(square);

        // Display the entire graphic structure
        composite2.Draw();

    }
}
