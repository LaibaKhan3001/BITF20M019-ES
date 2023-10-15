using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Ass_4_2
{

    public partial class Form1 : Form
    {
        private List<string> equationHistory = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + btn0.Text;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + btn1.Text;
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + btn3.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + btn6.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + btn9.Text;
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "+";
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "*";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "/";
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "-";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string equation = textBox1.Text;
            try
            {
                string result = EquationSolver.Solve(equation); // Call your solver method
                textBox1.Text = result; // Display the result
                string historyItem = $"{equation} = {result}";
                equationHistory.Add(historyItem);

                // Update the Label with the current session history
                UpdateHistoryLabel();

            }
            catch (Exception ex)
            {
                textBox1.Text = "Error: " + ex.Message; // Handle exceptions gracefully
            }
        }
        private void UpdateHistoryLabel()
        {
            // Join the history items into a single string to display in the Label
            historyLabel.Text = string.Join("\n", equationHistory);
        }


        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

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
}
