using FluentAssertions;
using TheNoobs.Requirements.Exceptions;
using Xunit;

namespace TheNoobs.Requirements.UnitTests;

public class RequirementTests
{
    [Theory]
    [InlineData("aaaaaaaaaa", "\\d+")]
    [InlineData("0123456789", "\\D+")]
    public void GivenRequirementWhenMatchFailThenThrow(string text, string pattern)
    {
        var action = () => Requirement.To().Match(text, pattern);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData("0123456789", "\\d+")]
    [InlineData("aaaaaaaaaa", "\\D+")]
    public void GivenRequirementWhenMatchThenReturn(string text, string pattern)
    {
        var action = () => Requirement.To().Match(text, pattern);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData("aaaaaaaaaa", "\\D+")]
    [InlineData("0123456789", "\\d+")]
    public void GivenRequirementWhenNotMatchFailThenThrow(string text, string pattern)
    {
        var action = () => Requirement.To().NotMatch(text, pattern);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData("0123456789", "\\D+")]
    [InlineData("aaaaaaaaaa", "\\d+")]
    public void GivenRequirementWhenNotMatchThenReturn(string text, string pattern)
    {
        var action = () => Requirement.To().NotMatch(text, pattern);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(null)]
    public void GivenRequirementWhenNotNullFailThenThrow(object? value)
    {
        var action = () => Requirement.To().NotBeNull(value);
        action.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void GivenRequirementWhenNotNullFailAndDelegatePassedThenThrowDelegatedException()
    {
        var action = () => Requirement.To().NotBeNull(null, () => new ArgumentNullException());
        action.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(0)]
    [InlineData("s")]
    [InlineData("a")]
    [InlineData(5)]
    public void GivenRequirementWhenNotNullThenReturn(object? value)
    {
        var action = () => Requirement.To().NotBeNull(value);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData("a")]
    [InlineData("ab")]
    [InlineData(1)]
    [InlineData(1.5)]
    public void GivenRequirementWhenNullFailThenThrow(object? value)
    {
        var action = () => Requirement.To().BeNull(value);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData(null)]
    public void GivenRequirementWhenNullThenReturn(object? value)
    {
        var action = () => Requirement.To().BeNull(value);
        action.Should().NotThrow();
    }

    [Fact]
    public void GivenRequirementWhenFalseFailThenThrow()
    {
        var action = () => Requirement.To().BeFalse(true);
        action.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void GivenRequirementWhenFalseThenReturn()
    {
        var action = () => Requirement.To().BeFalse(false);
        action.Should().NotThrow();
    }

    [Fact]
    public void GivenRequirementWhenTrueFailThenThrow()
    {
        var action = () => Requirement.To().BeTrue(false);
        action.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void GivenRequirementWhenTrueThenReturn()
    {
        var action = () => Requirement.To().BeTrue(true);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenRequirementWhenNotEmptyTextFailThenThrow(string value)
    {
        var action = () => Requirement.To().NotBeEmpty(value);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData("a")]
    public void GivenRequirementWhenNotEmptyTextThenReturn(string value)
    {
        var action = () => Requirement.To().NotBeEmpty(value);
        action.Should().NotThrow();
    }

    [Fact]
    public void GivenRequirementWhenNotEmptyCollectionFailThenThrow()
    {
        var action = () => Requirement.To().NotBeEmpty(Array.Empty<int>());
        action.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void GivenRequirementWhenNotEmptyCollectionThenReturn()
    {
        var action = () => Requirement.To().NotBeEmpty(Enumerable.Range(0, 1).ToList());
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData("a")]
    public void GivenRequirementWhenEmptyTextFailThenThrow(string value)
    {
        var action = () => Requirement.To().BeEmpty(value);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void GivenRequirementWhenEmptyTextThenReturn(string value)
    {
        var action = () => Requirement.To().BeEmpty(value);
        action.Should().NotThrow();
    }

    [Fact]
    public void GivenRequirementWhenEmptyCollectionFailThenThrow()
    {
        var collection = Enumerable.Range(0, 1).ToList();
        var action = () => Requirement.To().BeEmpty(collection);
        action.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void GivenRequirementWhenEmptyCollectionThenReturn()
    {
        var action = () => Requirement.To().BeEmpty(Array.Empty<int>());
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(30, 50)]
    public void GivenRequirementWhenIntValueGreaterThanOrEqualFailThenThrow(int value, int compareValue)
    {
        var action = () => Requirement.To().BeGreaterThanOrEqualTo(value, compareValue);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(50, 30)]
    public void GivenRequirementWhenIntValueGreaterThanOrEqualThenReturn(int value, int compareValue)
    {
        var action = () => Requirement.To().BeGreaterThanOrEqualTo(value, compareValue);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(30, 50)]
    public void GivenRequirementWhenLongValueGreaterThanOrEqualFailThenThrow(long value, long compareValue)
    {
        var action = () => Requirement.To().BeGreaterThanOrEqualTo(value, compareValue);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(50, 30)]
    public void GivenRequirementWhenLongValueGreaterThanOrEqualThenReturn(long value, long compareValue)
    {
        var action = () => Requirement.To().BeGreaterThanOrEqualTo(value, compareValue);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(30, 50)]
    public void GivenRequirementWhenDecimalValueGreaterThanOrEqualFailThenThrow(decimal value, decimal compareValue)
    {
        var action = () => Requirement.To().BeGreaterThanOrEqualTo(value, compareValue);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(50, 30)]
    public void GivenRequirementWhenDecimalValueGreaterThanOrEqualThenReturn(decimal value, decimal compareValue)
    {
        var action = () => Requirement.To().BeGreaterThanOrEqualTo(value, compareValue);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(30, 50)]
    public void GivenRequirementWhenDoubleValueGreaterThanOrEqualFailThenThrow(double value, double compareValue)
    {
        var action = () => Requirement.To().BeGreaterThanOrEqualTo(value, compareValue);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(50, 30)]
    public void GivenRequirementWhenDoubleValueGreaterThanOrEqualThenReturn(double value, double compareValue)
    {
        var action = () => Requirement.To().BeGreaterThanOrEqualTo(value, compareValue);
        action.Should().NotThrow();
    }

    [Fact]
    public void GivenRequirementWhenDateValueGreaterThanOrEqualFailThenThrow()
    {
        var action = () => Requirement.To().BeGreaterThanOrEqualTo(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
        action.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void GivenRequirementWhenDateValueGreaterThanOrEqualThenReturn()
    {
        var action = () => Requirement.To().BeGreaterThanOrEqualTo(DateTime.UtcNow.AddDays(1), DateTime.UtcNow);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(50, 30)]
    public void GivenRequirementWhenIntValueLessThanOrEqualFailThenThrow(int value, int compareValue)
    {
        var action = () => Requirement.To().BeLessThanOrEqualTo(value, compareValue);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(30, 50)]
    public void GivenRequirementWhenIntValueLessThanOrEqualThenReturn(int value, int compareValue)
    {
        var action = () => Requirement.To().BeLessThanOrEqualTo(value, compareValue);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(50, 30)]
    public void GivenRequirementWhenLongValueLessThanOrEqualFailThenThrow(long value, long compareValue)
    {
        var action = () => Requirement.To().BeLessThanOrEqualTo(value, compareValue);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(30, 50)]
    public void GivenRequirementWhenLongValueLessThanOrEqualFailThenReturn(long value, long compareValue)
    {
        var action = () => Requirement.To().BeLessThanOrEqualTo(value, compareValue);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(50, 30)]
    public void GivenRequirementWhenDecimalValueLessThanOrEqualFailThenThrow(decimal value, decimal compareValue)
    {
        var action = () => Requirement.To().BeLessThanOrEqualTo(value, compareValue);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(30, 50)]
    public void GivenRequirementWhenDecimalValueLessThanOrEqualThenReturn(decimal value, decimal compareValue)
    {
        var action = () => Requirement.To().BeLessThanOrEqualTo(value, compareValue);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(50, 30)]
    public void GivenRequirementWhenDoubleValueLessThanOrEqualFailThenThrow(double value, double compareValue)
    {
        var action = () => Requirement.To().BeLessThanOrEqualTo(value, compareValue);
        action.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(30, 50)]
    public void GivenRequirementWhenDoubleValueLessThanOrEqualFailThenReturn(double value, double compareValue)
    {
        var action = () => Requirement.To().BeLessThanOrEqualTo(value, compareValue);
        action.Should().NotThrow();
    }

    [Fact]
    public void GivenRequirementWhenDateValueLessThanOrEqualFailThenThrow()
    {
        var action = () => Requirement.To().BeLessThanOrEqualTo(DateTime.UtcNow.AddDays(1), DateTime.UtcNow);
        action.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void GivenRequirementWhenDateValueLessThanOrEqualThenReturn()
    {
        var action = () => Requirement.To().BeLessThanOrEqualTo(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
        action.Should().NotThrow();
    }

    [Fact]
    public void GivenRequirementWhenConfigureThenShouldSetToProperty()
    {
        var requirement = Requirement.To(() => new InvalidOperationException());

        var action = () => requirement.BeTrue(false);
        action.Should().Throw<InvalidOperationException>();
    }
}
