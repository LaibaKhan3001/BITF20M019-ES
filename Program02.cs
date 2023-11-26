// Mediator design pattern

using System;
using System.Collections.Generic;


// Example - 1
// Mediator Interface
public interface IChatMediator
{
    void SendMessage(string message, IUser user);
    void RegisterUser(IUser user);
}

// Concrete Mediator
public class ChatMediator : IChatMediator
{
    private List<IUser> users = new List<IUser>();

    public void RegisterUser(IUser user)
    {
        users.Add(user);
    }

    public void SendMessage(string message, IUser user)
    {
        foreach (var u in users)
        {
            // Exclude the sender
            if (u != user)
                u.ReceiveMessage(message);
        }
    }
}

// Colleague Interface
public interface IUser
{
    void SendMessage(string message);
    void ReceiveMessage(string message);
}

// Concrete Colleague
public class ChatUser : IUser
{
    private IChatMediator mediator;
    public string Name { get; private set; }

    public ChatUser(IChatMediator mediator, string name)
    {
        this.mediator = mediator;
        this.Name = name;
        mediator.RegisterUser(this);
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{Name} sending message: {message}");
        mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} received message: {message}");
    }
}


// Example - 2
// Mediator Interface
public interface IAirTrafficControl
{
    void RegisterAircraft(Aircraft aircraft);
    void SendWarning(Aircraft sender, string warning);
}

// Concrete Mediator
public class AirTrafficControl : IAirTrafficControl
{
    private List<Aircraft> aircrafts = new List<Aircraft>();

    public void RegisterAircraft(Aircraft aircraft)
    {
        aircrafts.Add(aircraft);
    }

    public void SendWarning(Aircraft sender, string warning)
    {
        foreach (var aircraft in aircrafts)
        {
            if (aircraft != sender)
                aircraft.ReceiveWarning(warning);
        }
    }
}

// Colleague Interface
public abstract class Aircraft
{
    protected IAirTrafficControl airTrafficControl;

    public Aircraft(IAirTrafficControl airTrafficControl)
    {
        this.airTrafficControl = airTrafficControl;
        airTrafficControl.RegisterAircraft(this);
    }

    public abstract void SendWarning(string warning);
    public abstract void ReceiveWarning(string warning);
}

// Concrete Colleague
public class PassengerPlane : Aircraft
{
    public PassengerPlane(IAirTrafficControl airTrafficControl) : base(airTrafficControl) { }

    public override void SendWarning(string warning)
    {
        Console.WriteLine("Passenger plane sending warning: " + warning);
        airTrafficControl.SendWarning(this, warning);
    }

    public override void ReceiveWarning(string warning)
    {
        Console.WriteLine("Passenger plane received warning: " + warning);
    }
}

// Concrete Colleague
public class CargoPlane : Aircraft
{
    public CargoPlane(IAirTrafficControl airTrafficControl) : base(airTrafficControl) { }

    public override void SendWarning(string warning)
    {
        Console.WriteLine("Cargo plane sending warning: " + warning);
        airTrafficControl.SendWarning(this, warning);
    }

    public override void ReceiveWarning(string warning)
    {
        Console.WriteLine("Cargo plane received warning: " + warning);
    }
}



// Client
class Program
{
    static void Main()
    {
        // Example - 1
        Console.WriteLine("Example 1:");
        IChatMediator mediator = new ChatMediator();

        IUser user1 = new ChatUser(mediator, "User1");
        IUser user2 = new ChatUser(mediator, "User2");
        IUser user3 = new ChatUser(mediator, "User3");

        user1.SendMessage("Hello, everyone!");


        // Example - 2
        Console.WriteLine("\nExample 2:");
        IAirTrafficControl atc = new AirTrafficControl();

        Aircraft passengerPlane = new PassengerPlane(atc);
        Aircraft cargoPlane = new CargoPlane(atc);

        passengerPlane.SendWarning("Traffic alert!");
    }
}
