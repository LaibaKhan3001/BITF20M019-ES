// Flyweight design pattern

using System;
using System.Collections.Generic;


// Example -1
// Flyweight interface
interface ICharacter
{
    void Display();
}

// Concrete Flyweight
class Character : ICharacter
{
    private char symbol;

    public Character(char symbol)
    {
        this.symbol = symbol;
    }

    public void Display()
    {
        Console.Write(symbol);
    }
}

// Flyweight Factory
class CharacterFactory
{
    private Dictionary<char, ICharacter> characters = new Dictionary<char, ICharacter>();

    public ICharacter GetCharacter(char key)
    {
        if (!characters.ContainsKey(key))
        {
            characters[key] = new Character(key);
        }

        return characters[key];
    }
}

// Example -2

// Flyweight interface
interface IMusicInstrument
{
    void Play(string note);
}

// Concrete Flyweight
class MusicInstrument : IMusicInstrument
{
    private string type;

    public MusicInstrument(string type)
    {
        this.type = type;
    }

    public void Play(string note)
    {
        Console.WriteLine($"{type} plays note: {note}");
    }
}

// Flyweight Factory
class MusicInstrumentFactory
{
    private Dictionary<string, IMusicInstrument> instruments = new Dictionary<string, IMusicInstrument>();

    public IMusicInstrument GetInstrument(string type)
    {
        if (!instruments.ContainsKey(type))
        {
            instruments[type] = new MusicInstrument(type);
        }

        return instruments[type];
    }
}




// Client
class Program
{
    static void Main()
    {
        // Example -1
        CharacterFactory characterFactory = new CharacterFactory();

        // Creating a sentence using flyweights
        ICharacter a = characterFactory.GetCharacter('A');
        ICharacter b = characterFactory.GetCharacter('B');
        ICharacter c = characterFactory.GetCharacter('C');
        ICharacter d = characterFactory.GetCharacter('D');

        List<ICharacter> sentence = new List<ICharacter> { a, b, c, a, b, c, d };

        // Display the sentence with flyweights
        foreach (var character in sentence)
        {
            character.Display();
        }

        Console.WriteLine("\n");

        // Example -2
        MusicInstrumentFactory instrumentFactory = new MusicInstrumentFactory();

        // Playing music using flyweights
        IMusicInstrument guitar = instrumentFactory.GetInstrument("Guitar");
        IMusicInstrument piano = instrumentFactory.GetInstrument("Piano");
        IMusicInstrument flute = instrumentFactory.GetInstrument("Flute");

        guitar.Play("C");
        piano.Play("E");
        flute.Play("G");
        guitar.Play("D");
        piano.Play("A");
    }
}

