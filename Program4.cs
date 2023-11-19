// Builder design pattern
using System;
using System.Collections.Generic;

// EXAMPLE # 1
// Product
class Product
{
    private List<string> parts = new List<string>();

    public void Add(string part)
    {
        parts.Add(part);
    }

    public void Show()
    {
        Console.WriteLine("\nProduct Parts:");

        foreach (var part in parts)
        {
            Console.WriteLine(part);
        }
    }
}

// Builder interface
interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    Product GetResult();
}

// Concrete Builder 1
class ConcreteBuilder1 : IBuilder
{
    private Product product = new Product();

    public void BuildPartA()
    {
        product.Add("PartA1");
    }

    public void BuildPartB()
    {
        product.Add("PartB1");
    }

    public Product GetResult()
    {
        return product;
    }
}

// Concrete Builder 2
class ConcreteBuilder2 : IBuilder
{
    private Product product = new Product();

    public void BuildPartA()
    {
        product.Add("PartA2");
    }

    public void BuildPartB()
    {
        product.Add("PartB2");
    }

    public Product GetResult()
    {
        return product;
    }
}

// Director
class Director
{
    public void Construct(IBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}



// EXAMPLE # 2

// Product
class Meal
{
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void Show()
    {
        Console.WriteLine("\nMeal contains:");

        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}

// Builder interface
interface IMealBuilder
{
    void BuildMainCourse();
    void BuildSide();
    void BuildDrink();
    Meal GetMeal();
}

// Concrete Builder: Healthy Meal
class HealthyMealBuilder : IMealBuilder
{
    private Meal meal = new Meal();

    public void BuildMainCourse()
    {
        meal.AddItem("Grilled Chicken Salad");
    }

    public void BuildSide()
    {
        meal.AddItem("Steamed Vegetables");
    }

    public void BuildDrink()
    {
        meal.AddItem("Water");
    }

    public Meal GetMeal()
    {
        return meal;
    }
}

// Concrete Builder: Fast Food Meal
class FastFoodMealBuilder : IMealBuilder
{
    private Meal meal = new Meal();

    public void BuildMainCourse()
    {
        meal.AddItem("Cheeseburger");
    }

    public void BuildSide()
    {
        meal.AddItem("French Fries");
    }

    public void BuildDrink()
    {
        meal.AddItem("Soda");
    }

    public Meal GetMeal()
    {
        return meal;
    }
}

// Director
class Waiter
{
    public void Construct(IMealBuilder builder)
    {
        builder.BuildMainCourse();
        builder.BuildSide();
        builder.BuildDrink();
    }
}

// Client code
class Client
{
    static void Main()
    {
        // EXAMPLE # 1
        Director director = new Director();

        IBuilder builder1 = new ConcreteBuilder1();
        director.Construct(builder1);
        Product product1 = builder1.GetResult();
        product1.Show();

        IBuilder builder2 = new ConcreteBuilder2();
        director.Construct(builder2);
        Product product2 = builder2.GetResult();
        product2.Show();
        Console.WriteLine("");

        // EXAMPLE # 2
        Waiter waiter = new Waiter();

        IMealBuilder healthyMealBuilder = new HealthyMealBuilder();
        waiter.Construct(healthyMealBuilder);
        Meal healthyMeal = healthyMealBuilder.GetMeal();
        healthyMeal.Show();

        IMealBuilder fastFoodMealBuilder = new FastFoodMealBuilder();
        waiter.Construct(fastFoodMealBuilder);
        Meal fastFoodMeal = fastFoodMealBuilder.GetMeal();
        fastFoodMeal.Show();
    }
}
