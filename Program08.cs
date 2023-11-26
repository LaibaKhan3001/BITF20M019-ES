// Visitor design pattern

using System;
using System.Collections.Generic;


// Example - 1 
// Visitor interface
public interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Rectangle rectangle);
}

// Element interface
public interface IShape
{
    void Accept(IShapeVisitor visitor);
}

// Concrete Elements
public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Concrete Visitor
public class AreaVisitor : IShapeVisitor
{
    public void Visit(Circle circle)
    {
        double area = Math.PI * Math.Pow(circle.Radius, 2);
        Console.WriteLine($"Area of circle: {area:F2}");
    }

    public void Visit(Rectangle rectangle)
    {
        double area = rectangle.Width * rectangle.Height;
        Console.WriteLine($"Area of rectangle: {area:F2}");
    }
}

// Example - 2
// Visitor interface
public interface IDocumentVisitor
{
    void Visit(PlainTextElement plainText);
    void Visit(HyperlinkElement hyperlink);
}

// Element interface
public interface IDocumentElement
{
    void Accept(IDocumentVisitor visitor);
}

// Concrete Elements
public class PlainTextElement : IDocumentElement
{
    public string Text { get; }

    public PlainTextElement(string text)
    {
        Text = text;
    }

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class HyperlinkElement : IDocumentElement
{
    public string Url { get; }
    public string Text { get; }

    public HyperlinkElement(string url, string text)
    {
        Url = url;
        Text = text;
    }

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Concrete Visitor
public class HtmlExportVisitor : IDocumentVisitor
{
    public void Visit(PlainTextElement plainText)
    {
        Console.WriteLine($"<p>{plainText.Text}</p>");
    }

    public void Visit(HyperlinkElement hyperlink)
    {
        Console.WriteLine($"<a href=\"{hyperlink.Url}\">{hyperlink.Text}</a>");
    }
}


// Client
class Program
{
    static void Main()
    {
        // Example - 1 
        Console.WriteLine("Example 1: ");
        List<IShape> shapes = new List<IShape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Circle(3.5)
        };

        IShapeVisitor areaVisitor = new AreaVisitor();

        foreach (var shape in shapes)
        {
            shape.Accept(areaVisitor);
        }

        // Example - 2
        Console.WriteLine("\nExample 2: ");
        List<IDocumentElement> documentElements = new List<IDocumentElement>
        {
            new PlainTextElement("This is a plain text."),
            new HyperlinkElement("https://example.com", "Visit Example.com"),
            new PlainTextElement("Another plain text.")
        };

        IDocumentVisitor htmlExportVisitor = new HtmlExportVisitor();

        foreach (var element in documentElements)
        {
            element.Accept(htmlExportVisitor);
        }
    }
}
