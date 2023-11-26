// Interpreter design pattern


using System;
using System.Collections.Generic;



// Example - 1
// Abstract Expression
public interface IExpression
{
    int Interpret(Dictionary<string, int> context);
}

// Terminal Expression
public class NumberExpression : IExpression
{
    private readonly int value;

    public NumberExpression(int value)
    {
        this.value = value;
    }

    public int Interpret(Dictionary<string, int> context)
    {
        return value;
    }
}

// Non-terminal Expression
public class AddExpression : IExpression
{
    private readonly IExpression left;
    private readonly IExpression right;

    public AddExpression(IExpression left, IExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public int Interpret(Dictionary<string, int> context)
    {
        return left.Interpret(context) + right.Interpret(context);
    }
}

// Example - 2
// Abstract Expression
public interface IQueryExpression
{
    string Interpret(Dictionary<string, string> context);
}

// Terminal Expression
public class FieldExpression : IQueryExpression
{
    private readonly string fieldName;

    public FieldExpression(string fieldName)
    {
        this.fieldName = fieldName;
    }

    public string Interpret(Dictionary<string, string> context)
    {
        return context.ContainsKey(fieldName) ? context[fieldName] : "Field not found";
    }
}

// Non-terminal Expression
public class SelectExpression : IQueryExpression
{
    private readonly IQueryExpression field;
    private readonly string tableName;

    public SelectExpression(IQueryExpression field, string tableName)
    {
        this.field = field;
        this.tableName = tableName;
    }

    public string Interpret(Dictionary<string, string> context)
    {
        string fieldValue = field.Interpret(context);
        return $"SELECT {fieldValue} FROM {tableName}";
    }
}

// Client
class Program
{
    static void Main()
    {
        // Example - 1
        Console.WriteLine("Example 1: ");
        // Context for variables
        Dictionary<string, int> context1 = new Dictionary<string, int>
        {
            { "a", 5 },
            { "b", 10 }
        };

        // a + b
        IExpression expression1 = new AddExpression(new NumberExpression(context1["a"]), new NumberExpression(context1["b"]));

        int result = expression1.Interpret(context1);
        Console.WriteLine($"Result: {result}"); 


        // Example - 2
        Console.WriteLine("\nExample 2: ");
        // Context for field values
        Dictionary<string, string> context2 = new Dictionary<string, string>
        {
            { "FirstName", "John" },
            { "LastName", "Doe" }
        };

        // SELECT FirstName FROM Users
        IQueryExpression expression2 = new SelectExpression(new FieldExpression("FirstName"), "Users");

        string query = expression2.Interpret(context2);
        Console.WriteLine($"Query: {query}"); 
    }
}
