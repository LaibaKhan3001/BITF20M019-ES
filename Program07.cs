// State design pattern

using System;


// Exmaple - 1
// Context
public class TrafficLight
{
    private ITrafficLightState state;

    public TrafficLight()
    {
        state = new RedState(this);
    }

    public void SetState(ITrafficLightState state)
    {
        this.state = state;
    }

    public void Change()
    {
        state.Change();
    }
}

// State interface
public interface ITrafficLightState
{
    void Change();
}

// Concrete States
public class RedState : ITrafficLightState
{
    private readonly TrafficLight trafficLight;

    public RedState(TrafficLight trafficLight)
    {
        this.trafficLight = trafficLight;
    }

    public void Change()
    {
        Console.WriteLine("Changing to Green");
        trafficLight.SetState(new GreenState(trafficLight));
    }
}

public class GreenState : ITrafficLightState
{
    private readonly TrafficLight trafficLight;

    public GreenState(TrafficLight trafficLight)
    {
        this.trafficLight = trafficLight;
    }

    public void Change()
    {
        Console.WriteLine("Changing to Yellow");
        trafficLight.SetState(new YellowState(trafficLight));
    }
}

public class YellowState : ITrafficLightState
{
    private readonly TrafficLight trafficLight;

    public YellowState(TrafficLight trafficLight)
    {
        this.trafficLight = trafficLight;
    }

    public void Change()
    {
        Console.WriteLine("Changing to Red");
        trafficLight.SetState(new RedState(trafficLight));
    }
}

// Exmaple - 2
// Context
public class Fan
{
    private IFanState state;

    public Fan()
    {
        state = new OffState(this);
    }

    public void SetState(IFanState state)
    {
        this.state = state;
    }

    public void PullChain()
    {
        state.PullChain();
    }
}

// State interface
public interface IFanState
{
    void PullChain();
}

// Concrete States
public class OffState : IFanState
{
    private readonly Fan fan;

    public OffState(Fan fan)
    {
        this.fan = fan;
    }

    public void PullChain()
    {
        Console.WriteLine("Turning fan to low");
        fan.SetState(new LowState(fan));
    }
}

public class LowState : IFanState
{
    private readonly Fan fan;

    public LowState(Fan fan)
    {
        this.fan = fan;
    }

    public void PullChain()
    {
        Console.WriteLine("Turning fan to medium");
        fan.SetState(new MediumState(fan));
    }
}

public class MediumState : IFanState
{
    private readonly Fan fan;

    public MediumState(Fan fan)
    {
        this.fan = fan;
    }

    public void PullChain()
    {
        Console.WriteLine("Turning fan to high");
        fan.SetState(new HighState(fan));
    }
}

public class HighState : IFanState
{
    private readonly Fan fan;

    public HighState(Fan fan)
    {
        this.fan = fan;
    }

    public void PullChain()
    {
        Console.WriteLine("Turning fan off");
        fan.SetState(new OffState(fan));
    }
}

// Client
class Program
{
    static void Main()
    {
        // Exmaple - 1
        Console.WriteLine("Example 1: ");
        TrafficLight trafficLight = new TrafficLight();

        trafficLight.Change(); // Changing to Green
        trafficLight.Change(); // Changing to Yellow
        trafficLight.Change(); // Changing to Red

        // Exmaple - 2
        Console.WriteLine("\nExample 2: ");
        Fan fan = new Fan();

        fan.PullChain(); // Turning fan to low
        fan.PullChain(); // Turning fan to medium
        fan.PullChain(); // Turning fan to high
        fan.PullChain(); // Turning fan off
    }
}
