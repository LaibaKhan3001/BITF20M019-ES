// Factory design pattern


using System;


// EXAMPLE # 1
// Interface for the product
public interface IShape
{
    void Draw();
}

// Concrete implementations of the product
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

public class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Rectangle");
    }
}

// Factory interface to create objects
public interface IShapeFactory
{
    IShape CreateShape();
}

// Concrete factories for each type of product
public class CircleFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Circle();
    }
}

public class RectangleFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Rectangle();
    }
}




// EXAMPLE # 2

// Interface for the product
public interface IAnimal
{
    void Speak();
}

// Concrete implementations of the product
public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Dog says woof!");
    }
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Cat says meow!");
    }
}

// Factory interface to create objects
public interface IAnimalFactory
{
    IAnimal CreateAnimal();
}

// Concrete factories for each type of product
public class DogFactory : IAnimalFactory
{
    public IAnimal CreateAnimal()
    {
        return new Dog();
    }
}

public class CatFactory : IAnimalFactory
{
    public IAnimal CreateAnimal()
    {
        return new Cat();
    }
}


class Program
{
    static void Main()
    {
        // EXAMPLE # 1
        IShapeFactory circleFactory = new CircleFactory();
        IShape circle = circleFactory.CreateShape();
        circle.Draw();

        IShapeFactory rectangleFactory = new RectangleFactory();
        IShape rectangle = rectangleFactory.CreateShape();
        rectangle.Draw();
        Console.WriteLine("");

        // EXAMPLE # 2
        IAnimalFactory dogFactory = new DogFactory();
        IAnimal dog = dogFactory.CreateAnimal();
        dog.Speak();

        IAnimalFactory catFactory = new CatFactory();
        IAnimal cat = catFactory.CreateAnimal();
        cat.Speak();
    }
}
