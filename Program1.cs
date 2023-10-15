// Task-01
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class EquationSolver
{
    public static string Solve(string equation)
    {
        equation = NormalizeEquation(equation);
        if (!IsValid(equation))
            return "Invalid equation";

        var result = Calculate(equation);
        return result.ToString("0.######"); // Display up to 6 decimal places.
    }

    private static string NormalizeEquation(string equation)
    {
        // Remove spaces and ensure there is a space around each operator.
        equation = equation.Replace(" ", "");
        equation = Regex.Replace(equation, "([+*/\\-()])", " $1 ");

        // Handle negative numbers (e.g., "-3" should be considered as "0 - 3").
        equation = Regex.Replace(equation, "(-\\d+)", "0 $1");

        // Remove redundant plus signs (e.g., "+++").
        equation = Regex.Replace(equation, "\\++", "+");

        // Trim leading/trailing spaces.
        equation = equation.Trim();

        return equation;
    }

    private static bool IsValid(string equation)
    {
        // Check for invalid characters or operators.
        if (Regex.IsMatch(equation, @"[^0-9+\-*/(). ]"))
            return false;

        // Check for unbalanced brackets.
        int openBrackets = equation.Count(c => c == '(');
        int closeBrackets = equation.Count(c => c == ')');
        if (openBrackets != closeBrackets)
            return false;

        // Check for consecutive operators without operands.
        if (Regex.IsMatch(equation, "[+\\-*/]{2,}"))
            return false;

        // Check for incomplete expressions.
        if (Regex.IsMatch(equation, "[+\\-*/]$"))
            return false;

        return true;
    }

    private static double Calculate(string equation)
    {
        var postfix = InfixToPostfix(equation);
        var stack = new Stack<double>();

        foreach (var token in postfix)
        {
            if (double.TryParse(token, out double operand))
            {
                stack.Push(operand);
            }
            else
            {
                if (stack.Count >= 2)
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    double result = 0;

                    switch (token)
                    {
                        case "+":
                            result = a + b;
                            break;
                        case "-":
                            result = a - b;
                            break;
                        case "*":
                            result = a * b;
                            break;
                        case "/":
                            if (b != 0)
                                result = a / b;
                            else
                                return double.NaN; // Handle division by zero.
                            break;
                    }

                    stack.Push(result);
                }
                else
                {
                    // Handle the case where there are not enough operands for an operator.
                    return double.NaN;
                }
            }
        }

        if (stack.Count == 1)
        {
            return stack.Pop();
        }

        // Handle any remaining cases or errors.
        return double.NaN;
    }

    private static List<string> InfixToPostfix(string equation)
    {
        var output = new List<string>();
        var stack = new Stack<string>();
        var operators = new Dictionary<string, int>
    {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 }
    };

        string[] tokens = equation.Split(' ');

        foreach (var token in tokens)
        {
            if (double.TryParse(token, out _))
            {
                output.Add(token);
            }
            else if (token == "(")
            {
                stack.Push(token);
            }
            else if (token == ")")
            {
                while (stack.Count > 0 && stack.Peek() != "(")
                {
                    output.Add(stack.Pop());
                }
                if (stack.Count > 0 && stack.Peek() == "(")
                {
                    stack.Pop(); // Pop the open parenthesis.
                }
            }
            else if (operators.ContainsKey(token))
            {
                while (stack.Count > 0 && operators.ContainsKey(stack.Peek()) &&
                    operators[token] <= operators[stack.Peek()])
                {
                    output.Add(stack.Pop());
                }
                stack.Push(token);
            }
        }

        while (stack.Count > 0)
        {
            output.Add(stack.Pop());
        }

        return output;
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Equation Solver Menu");
            Console.WriteLine("1. Solve Equation");
            Console.WriteLine("2. Exit");
            Console.Write("Select an option: ");

            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.Write("Enter an equation: ");
                string equation = Console.ReadLine();
                string result = Solve(equation);
                Console.WriteLine($"Result: {result}");
            }
            else if (userInput == "2")
            {
                Console.WriteLine("Exiting the program.");
                break; // Exit the loop and end the program
            }
            else
            {
                Console.WriteLine("Invalid option. Please select a valid option (1 or 2).");
            }
        }
    }
}
