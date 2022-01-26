Console.WriteLine("Enter an arithmetic notation");
var input = Console.ReadLine();

var infixTokens = Tokenize(input);
var postfixTokens = InfixToPostfix(infixTokens);
var result = CalculatePostfix(postfixTokens);

List<string> Tokenize(string expression)
{
    var stringNoSpace = expression.Replace(" ", "");
    List<string> tokens = new List<string>();
    var num = "";

    foreach (var symbol in stringNoSpace)
    {
        if (symbol >= '0' && symbol <= '9')
        {
            num += symbol;
        }
        else
        {
            tokens.Add(num);
            num = "";
            tokens.Add(symbol.ToString());
        }
    }

    if (num != "")
    {
        tokens.Add(num);
    }

    return tokens;
}

int Precedence(string op)
{
    if (op == "^")
    {
        return 3;
    }
    if (op == "*" || op == "/")
    {
        return 2;
    }
    if (op == "+" || op == "-")
    {
        return 1;
    }

    return -1;
}

Queue<string> InfixToPostfix(List<string> tokens)
{
    Queue<string> output = new Queue<string>();
    Stack<string> operatorStack = new Stack<string>();

    List<string> operators = new List<string>() {"*", "-", "+", "/", "^"};

    foreach (var token in tokens)
    {
        if (operators.Contains(token))
        {
            if (operatorStack.Count != 0)
            {
                var previousValue = operatorStack.Peek();
                if (Precedence(previousValue) >= Precedence(token))
                {
                    output.Enqueue(previousValue);
                }
            }

            operatorStack.Push(token);

        }

        else
        {
            output.Enqueue(token);
        }

    }
    if (operatorStack.Count != 0)
    {
        output.Enqueue(operatorStack.Pop());
    }

    return output;
}

int CalculatePostfix(Queue<string> tokens)
{
    List<string> operators = new List<string>() {"*", "-", "+", "/", "^"};

    Stack<int> output = new Stack<int>();

    foreach (var token in tokens)
    {
        if (!operators.Contains(token))
        {
            var num = Int32.Parse(token);
            output.Push(num);
        }

        else
        {
            var num1 = output.Pop();
            var num2 = output.Pop();
            switch (token)
            {
                case "*":
                    output.Push(num1 * num2);
                    break;
                case "-":
                    output.Push(num2 - num1);
                    break;
                case "+":
                    output.Push(num1 + num2);
                    break;
                case "/":
                    output.Push(num2 / num1);
                    break;
                case "^":
                    var double1 = Convert.ToDouble(num1);
                    var double2 = Convert.ToDouble(num2);
                    var powerResult = Math.Pow(double2, double1);
                    output.Push(Convert.ToInt32(powerResult));
                    break;
            }
        }
    }

    var finalInt = output.Pop();

    return finalInt;
}

Console.WriteLine(result);
