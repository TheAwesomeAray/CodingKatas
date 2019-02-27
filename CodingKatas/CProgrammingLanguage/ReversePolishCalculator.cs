using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas.CProgrammingLanguage
{
    public class Stack
    {
        private int top;
        private string[] values;

        public Stack()
        {
            top = -1;
            values = new string[10];
        }

        public Stack(string[] values)
        {
            this.values = values;
            top = values.Length - 1;
        }

        public string Pop()
        {
            if (top >= 0)
                return values[top--];
            else
                throw new InvalidOperationException("Stack Empty");
        }

        public void Push(string value)
        {
            if (top < values.Length - 1)
                values[++top] = value;
        }

        public bool IsEmpty()
        {
            return top < 0;
        }

        public string Peek()
        {
            if (IsEmpty())
                return null;
            else
                return values[top];
        }

        private void Resize()
        {
            var copy = new string[values.Length * 2];
            values.CopyTo(copy, 0);
            values = copy;
        }
    }

    public class ReversePolishCalculator
    {
        public double Calculate(string input)
        {
            var stack = new Stack(Split(input));

            for (int i = 0; i < input.Length; i++)
            {
                double op1 = ConvertToDigit(stack.Pop());
                double op2 = ConvertToDigit(stack.Pop());
                string op = stack.Pop();
                switch (op)
                {
                    case "+":
                        return op1 + op2;
                    case "*":
                        return op1 * op2;
                    default:
                        throw new InvalidOperationException("Invalid Operator");
                }
            }

            return 0;
        }

        private string[] Split(string input)
        {
            int spaceCount = GetSpaceCount(input);
            string[] result = new string[spaceCount + 1];
            int j = input.Length - 1;
            for(int i = 0; i < result.Length; i++)
            {
                string expressionComponent = "";
                for (; j >= 0 && input[j] != ' '; j--)
                {
                    expressionComponent += input[j];
                }
                    j--;

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
            for (int i = input.Length - 1; i >= 0; i--)
            {
                result = result * 10 + input[i] - '0';
            }

            return result;
        }
    }
}
