// Prototype design pattern
using System;


// EXAMPLE - 1
// Concrete Prototype: Animal
class Animal : ICloneable
{
    public string Species { get; set; }
    public string Habitat { get; set; }

    public Animal(string species, string habitat)
    {
        Species = species;
        Habitat = habitat;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public void Display()
    {
        Console.WriteLine($"Animal - Species: {Species}, Habitat: {Habitat}");
    }
}

// Concrete Prototype: Bird
class Bird : Animal
{
    public Bird(string species) : base(species, "Sky") { }
}


// EXAMPLE - 2
// Concrete Prototype: Product
class Product : ICloneable
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public void Display()
    {
        Console.WriteLine($"Product - Name: {Name}, Price: ${Price}");
    }
}

// Concrete Prototype: ElectronicDevice
class ElectronicDevice : Product
{
    public ElectronicDevice(string name) : base(name, 0.0) { }
}

// Client code
class Client
{
    static void Main()
    {
        // EXAMPLE - 1
        // Create prototype animals
        Animal originalLion = new Animal("Lion", "Grasslands");
        Animal originalEagle = new Bird("Eagle");

        // Clone and display cloned animals
        Animal clonedLion = (Animal)originalLion.Clone();
        clonedLion.Display();

        Animal clonedEagle = (Animal)originalEagle.Clone();
        clonedEagle.Display();
        Console.WriteLine();

        // EXAMPLE - 2
        // Create prototype products
        Product originalBook = new Product("Book", 19.99);
        Product originalPhone = new ElectronicDevice("Smartphone");

        // Clone and display cloned products
        Product clonedBook = (Product)originalBook.Clone();
        clonedBook.Display();

        Product clonedPhone = (Product)originalPhone.Clone();
        clonedPhone.Display();
    }
}
