using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas.CProgrammingLanguage
{
    public class ReversePolishCalculator
    {
        double[] val;
        int sp = 0;

        public double Calculate(string input)
        {
            val = Split(input);
            sp = val.Length;

            for (int i = 0; i < input.Length; i++)
            {
                double op1 = Pop();
                double op2 = Pop();
                return op1 + op2;
            }

            return 0;
        }

        private double[] Split(string input)
        {
            int spaceCount = GetSpaceCount(input);
            double[] result = new double[spaceCount + 1];
            int j = input.Length - 1;
            for(int i = 0; i < result.Length; i++)
            {
                string expressionComponent = "";
                for (; j >= 0 && input[j] != ' '; j--)
                {
                    expressionComponent += input[j];
                }
                    j--;

                result[i] = ConvertToDigit(expressionComponent);
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

        private void Push(double value)
        {
            if (sp < val.Length - 1)
                val[sp++] = value;
        }

        private double Pop()
        {
            if (sp > 0)
                return val[--sp];
            else
                throw new InvalidOperationException("Stack Empty");

            
        }
    }
}
