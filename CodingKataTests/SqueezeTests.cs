using CodingKatas;
using FluentAssertions;
using Xunit;


public class SqueezeTests
{
    [Fact]
    public void Squeeze_GivenMatchingStrings_ReturnsEmptyString()
    {
        string s1 = "123";
        string s2 = "123";

        new SqueezeKata().Squeeze(s1, s2).Should().Be("");
    }
}

