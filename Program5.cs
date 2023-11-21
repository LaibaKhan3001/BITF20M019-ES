// Facade design pattern

using System;


// Example - 1
// Subsystem components
class Amplifier
{
    public void TurnOn() => Console.WriteLine("Amplifier is ON");
    public void TurnOff() => Console.WriteLine("Amplifier is OFF");
}

class DVDPlayer
{
    public void Play() => Console.WriteLine("DVD Player is playing");
    public void Stop() => Console.WriteLine("DVD Player stopped");
}

class Projector
{
    public void TurnOn() => Console.WriteLine("Projector is ON");
    public void TurnOff() => Console.WriteLine("Projector is OFF");
}

class Lights
{
    public void Dim() => Console.WriteLine("Lights are dimmed");
    public void Brighten() => Console.WriteLine("Lights are brightened");
}

// Facade
class HomeTheaterFacade
{
    private Amplifier amplifier;
    private DVDPlayer dvdPlayer;
    private Projector projector;
    private Lights lights;

    public HomeTheaterFacade(Amplifier amplifier, DVDPlayer dvdPlayer, Projector projector, Lights lights)
    {
        this.amplifier = amplifier;
        this.dvdPlayer = dvdPlayer;
        this.projector = projector;
        this.lights = lights;
    }

    public void WatchMovie()
    {
        Console.WriteLine("Get ready to watch a movie!");
        amplifier.TurnOn();
        dvdPlayer.Play();
        projector.TurnOn();
        lights.Dim();
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting down the home theater system.");
        amplifier.TurnOff();
        dvdPlayer.Stop();
        projector.TurnOff();
        lights.Brighten();
    }
}



// Example - 2
// Subsystem components
class CPU
{
    public void Start() => Console.WriteLine("CPU is starting");
    public void Stop() => Console.WriteLine("CPU is stopping");
}

class Memory
{
    public void Load() => Console.WriteLine("Memory is loading");
    public void Unload() => Console.WriteLine("Memory is unloading");
}

class HardDrive
{
    public void Read() => Console.WriteLine("Hard Drive is reading");
    public void Write() => Console.WriteLine("Hard Drive is writing");
}

// Facade
class ComputerFacade
{
    private CPU cpu;
    private Memory memory;
    private HardDrive hardDrive;

    public ComputerFacade(CPU cpu, Memory memory, HardDrive hardDrive)
    {
        this.cpu = cpu;
        this.memory = memory;
        this.hardDrive = hardDrive;
    }

    public void Start()
    {
        Console.WriteLine("Starting the computer...");
        cpu.Start();
        memory.Load();
        hardDrive.Read();
        Console.WriteLine("Computer started successfully.");
    }

    public void Stop()
    {
        Console.WriteLine("Shutting down the computer...");
        cpu.Stop();
        memory.Unload();
        hardDrive.Write();
        Console.WriteLine("Computer shut down successfully.");
    }
}



// Client
class Program
{
    static void Main()
    {
        // Example - 1
        // Create subsystem components
        Amplifier amplifier = new Amplifier();
        DVDPlayer dvdPlayer = new DVDPlayer();
        Projector projector = new Projector();
        Lights lights = new Lights();

        // Create the facade with these components
        HomeTheaterFacade homeTheater = new HomeTheaterFacade(amplifier, dvdPlayer, projector, lights);

        // Use the facade to watch a movie
        homeTheater.WatchMovie();

        // Use the facade to end the movie
        homeTheater.EndMovie();
        Console.WriteLine();


        // Example - 2
        // Create subsystem components
        CPU cpu = new CPU();
        Memory memory = new Memory();
        HardDrive hardDrive = new HardDrive();

        // Create the facade with these components
        ComputerFacade computerFacade = new ComputerFacade(cpu, memory, hardDrive);

        // Use the facade to start the computer
        computerFacade.Start();

        // Use the facade to stop the computer
        computerFacade.Stop();
    }
}
