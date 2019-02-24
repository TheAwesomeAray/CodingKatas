using CodingKatas;
using FluentAssertions;
using Xunit;

public class BinarySearchTests
{
    [Theory]
    [InlineData(1, new[] { 2 })]
    [InlineData(4, new[] { 2, 3 })]
    [InlineData(5, new[] { 1, 2, 3, 4, 6, 7, 8, 9 })]
    public void Search_ValueNotInArray_ReturnsNegative1(int searchTerm, int[] searchArray)
    {
        new BinarySearchKata().Search(searchTerm, searchArray, searchArray.Length).Should().Be(-1);
    }

    [Theory]
    [InlineData(2, new[] { 2 }, 0)]
    [InlineData(4, new[] { 2, 3, 4 }, 2)]
    [InlineData(5, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 4)]
    public void Search_ValueInArray_ReturnsIndexOfValue(int searchTerm, int[] searchArray, int expected)
    {
        new BinarySearchKata().Search(searchTerm, searchArray, searchArray.Length).Should().Be(expected);
    }
}

