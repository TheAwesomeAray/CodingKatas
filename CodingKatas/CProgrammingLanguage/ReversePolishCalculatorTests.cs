using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingKatas.CProgrammingLanguage
{
    public class ReversePolishCalculatorTests
    {
        [Theory]
        [InlineData("1 2 + \n", 3)]
        [InlineData("5 4 + \n", 9)]
        [InlineData("9 9 + \n", 18)]
        public void Calculate_GivenSingleDigitOperandsAndPlusSign_ReturnsSum(string input, double expected)
        {
            new ReversePolishCalculator().Calculate(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("11 2 + \n", 13)]
        [InlineData("5 45 + \n", 50)]
        [InlineData("300 350 + \n", 650)]
        public void Calculate_GivenMultipleDigitOperandsAndPlusSign_ReturnsSum(string input, double expected)
        {
            new ReversePolishCalculator().Calculate(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("2 2 * \n", 4)]
        [InlineData("5 4 * \n", 20)]
        [InlineData("9 9 * \n", 81)]
        public void Calculate_GivenSingleDigitOperandsAndAsterisk_ReturnsProduct(string input, double expected)
        {
            new ReversePolishCalculator().Calculate(input).Should().Be(expected);
        }
    }
}
