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
        [InlineData("1 2 +", 3)]
        [InlineData("5 4 +", 9)]
        [InlineData("9 9 +", 18)]
        public void Calculate_GivenSingleDigitOperandsAndPlusSign_ReturnsSum(string input, double expected)
        {
            new ReversePolishCalculator().Calculate(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("11 2 +", 13)]
        [InlineData("5 45 +", 50)]
        [InlineData("300 350 +", 650)]
        public void Calculate_GivenMultipleDigitOperandsAndPlusSign_ReturnsSum(string input, double expected)
        {
            new ReversePolishCalculator().Calculate(input).Should().Be(expected);
        }
    }
}
