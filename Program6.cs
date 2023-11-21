// Bridge design pattern

using System;


// Example -1
// Implementor interface
interface IDrawingImplementor
{
    void DrawCircle(int radius, int x, int y);
    void DrawSquare(int side, int x, int y);
}

// Concrete Implementors
class DrawingApiV1 : IDrawingImplementor
{
    public void DrawCircle(int radius, int x, int y)
    {
        Console.WriteLine($"Drawing circle with API v1 at ({x}, {y}) with radius {radius}");
    }

    public void DrawSquare(int side, int x, int y)
    {
        Console.WriteLine($"Drawing square with API v1 at ({x}, {y}) with side {side}");
    }
}

class DrawingApiV2 : IDrawingImplementor
{
    public void DrawCircle(int radius, int x, int y)
    {
        Console.WriteLine($"Drawing circle with API v2 at ({x}, {y}) with radius {radius}");
    }

    public void DrawSquare(int side, int x, int y)
    {
        Console.WriteLine($"Drawing square with API v2 at ({x}, {y}) with side {side}");
    }
}

// Abstraction
abstract class Shape
{
    protected IDrawingImplementor drawingImplementor;

    protected Shape(IDrawingImplementor drawingImplementor)
    {
        this.drawingImplementor = drawingImplementor;
    }

    public abstract void Draw();
}

// Refined Abstractions
class Circle : Shape
{
    private int radius;
    private int x;
    private int y;

    public Circle(int radius, int x, int y, IDrawingImplementor drawingImplementor)
        : base(drawingImplementor)
    {
        this.radius = radius;
        this.x = x;
        this.y = y;
    }

    public override void Draw()
    {
        drawingImplementor.DrawCircle(radius, x, y);
    }
}

class Square : Shape
{
    private int side;
    private int x;
    private int y;

    public Square(int side, int x, int y, IDrawingImplementor drawingImplementor)
        : base(drawingImplementor)
    {
        this.side = side;
        this.x = x;
        this.y = y;
    }

    public override void Draw()
    {
        drawingImplementor.DrawSquare(side, x, y);
    }
}



// Example - 2
// Implementor interface
interface IDevice
{
    void TurnOn();
    void TurnOff();
    void SetChannel(int channel);
}

// Concrete Implementors
class TV : IDevice
{
    private bool isOn = false;
    private int currentChannel = 0;

    public void TurnOn()
    {
        isOn = true;
        Console.WriteLine("TV is ON");
    }

    public void TurnOff()
    {
        isOn = false;
        Console.WriteLine("TV is OFF");
    }

    public void SetChannel(int channel)
    {
        if (isOn)
        {
            currentChannel = channel;
            Console.WriteLine($"TV: Channel set to {channel}");
        }
        else
        {
            Console.WriteLine("TV is OFF. Cannot set channel.");
        }
    }
}

class Radio : IDevice
{
    private bool isOn = false;
    private int currentChannel = 0;

    public void TurnOn()
    {
        isOn = true;
        Console.WriteLine("Radio is ON");
    }

    public void TurnOff()
    {
        isOn = false;
        Console.WriteLine("Radio is OFF");
    }

    public void SetChannel(int channel)
    {
        if (isOn)
        {
            currentChannel = channel;
            Console.WriteLine($"Radio: Channel set to {channel}");
        }
        else
        {
            Console.WriteLine("Radio is OFF. Cannot set channel.");
        }
    }
}

// Abstraction
abstract class RemoteControl
{
    protected IDevice device;

    protected RemoteControl(IDevice device)
    {
        this.device = device;
    }

    public abstract void TurnOn();
    public abstract void TurnOff();
    public abstract void SetChannel(int channel);
}

// Refined Abstractions
class BasicRemoteControl : RemoteControl
{
    public BasicRemoteControl(IDevice device) : base(device) { }

    public override void TurnOn()
    {
        device.TurnOn();
    }

    public override void TurnOff()
    {
        device.TurnOff();
    }

    public override void SetChannel(int channel)
    {
        device.SetChannel(channel);
    }
}

// AdvancedRemoteControl class
class AdvancedRemoteControl : RemoteControl
{
    public AdvancedRemoteControl(IDevice device) : base(device) { }

    public void Mute()
    {
        Console.WriteLine("Device is muted");
    }

    // Implementation of TurnOn is required
    public override void TurnOn()
    {
        device.TurnOn();
    }

    // Implementation of TurnOff is required
    public override void TurnOff()
    {
        device.TurnOff();
    }

    // Implementation of SetChannel is required
    public override void SetChannel(int channel)
    {
        device.SetChannel(channel);
    }
}




// Client
class Program
{
    static void Main()
    {
        // Example -1
        IDrawingImplementor drawingApiV1 = new DrawingApiV1();
        IDrawingImplementor drawingApiV2 = new DrawingApiV2();

        Shape circleApiV1 = new Circle(5, 10, 20, drawingApiV1);
        Shape squareApiV2 = new Square(4, 15, 25, drawingApiV2);

        circleApiV1.Draw();
        squareApiV2.Draw();

        Console.WriteLine();


        // Example -2

        IDevice tv = new TV();
        IDevice radio = new Radio();

        RemoteControl basicRemote = new BasicRemoteControl(tv);
        RemoteControl advancedRemote = new AdvancedRemoteControl(radio);

        basicRemote.TurnOn();
        basicRemote.SetChannel(5);
        basicRemote.TurnOff();

        advancedRemote.TurnOn();
        advancedRemote.SetChannel(102);
        (advancedRemote as AdvancedRemoteControl)?.Mute();
        advancedRemote.TurnOff();
    }
}
