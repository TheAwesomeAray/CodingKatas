using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas.CProgrammingLanguage
{
    public class Stack
    {
        private int top;
        private double[] values;

        public Stack()
        {
            top = -1;
            values = new double[10];
        }

        public Stack(double[] values)
        {
            this.values = values;
            top = values.Length - 1;
        }

        public double Pop()
        {
            if (top >= 0)
                return values[top--];
            else
                throw new InvalidOperationException("Stack Empty");
        }

        public void Push(double value)
        {
            if (top < values.Length - 1)
                values[++top] = value;
        }

        public bool IsEmpty()
        {
            return top < 0;
        }

        public double? Peek()
        {
            if (IsEmpty())
                return null;
            else
                return values[top];
        }

        private void Resize()
        {
            var copy = new double[values.Length * 2];
            values.CopyTo(copy, 0);
            values = copy;
        }
    }

    public class ReversePolishCalculator
    {
        public double Calculate(string input)
        {
            var result = Split(input);
            var stack = new Stack();

            for (int i = 0; i < result.Length; i++)
            {
                if (IsDigit(result[i]))
                    stack.Push(ConvertToDigit(result[i]));
                else
                {
                    switch (result[i])
                    {
                        case "+":
                            stack.Push(stack.Pop() + stack.Pop());
                            break;
                        case "*":
                            stack.Push(stack.Pop() * stack.Pop());
                            break;
                        case "\n":
                            return stack.Pop();
                        default:
                            throw new InvalidOperationException("Invalid Operator");
                    }
                }
                
            }

            return 0;
        }

        private bool IsDigit(string s)
        {
            int decimalCount = 0;
            for (int i = 0; i < s.Length; i++)
                if (!char.IsDigit(s[i]) || decimalCount > 1)
                    return false;
                else if (s[i] == '.')
                    decimalCount++;

            return true;
        }

        private string[] Split(string input)
        {
            int spaceCount = GetSpaceCount(input);
            string[] result = new string[spaceCount + 1];
            int j = 0;
            for (int i = 0; i < result.Length; i++)
            {
                string expressionComponent = "";
                
                for (; j < input.Length && input[j] != ' '; j++)
                {
                    expressionComponent += input[j];
                }

                j++;

                result[i] = expressionComponent;
            }

            return result;
        }

        public int GetSpaceCount(string input)
        {
            int k = 0;
            for (int i = 0; i < input.Length; i++)
                if (input[i] == ' ')
                    k++;

            return k;
        }

        private double ConvertToDigit(string input)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result = result * 10 + input[i] - '0';
            }

            return result;
        }
    }
}
