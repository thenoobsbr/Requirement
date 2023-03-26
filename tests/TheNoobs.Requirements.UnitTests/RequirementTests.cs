using Xunit;
using FluentAssertions;
using System.Collections;
using TheNoobs.Requirements.Exceptions;

public class RequirementTests
{
    public static IEnumerable<object[]> NotBeNull_TestData =>
        new List<object[]>
        {
            new object[] { "some string" },
            new object[] { 42 },
            new object[] { new object() }
        };

    [Theory]
    [MemberData(nameof(NotBeNull_TestData))]
    public void NotBeNull_ShouldNotThrowException_WhenObjectIsNotNull(object value)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.NotBeNull(value);

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void NotBeNull_ShouldThrowException_WhenObjectIsNull()
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.NotBeNull(null);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void BeNull_ShouldNotThrowException_WhenObjectIsNull()
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeNull(null);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(NotBeNull_TestData))]
    public void BeNull_ShouldThrowException_WhenObjectIsNotNull(object value)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeNull(value);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void BeTrue_ShouldNotThrowException_WhenConditionIsTrue()
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeTrue(true);

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void BeTrue_ShouldThrowException_WhenConditionIsFalse()
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeTrue(false);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void BeFalse_ShouldNotThrowException_WhenConditionIsFalse()
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeFalse(false);

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void BeFalse_ShouldThrowException_WhenConditionIsTrue()
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeFalse(true);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    [Fact]
    public void BeOfType_ShouldNotThrowException_WhenObjectIsOfType()
    {
        // Arrange
        var requirement = Requirement.To();
        object value = "some string";

        // Act
        Action act = () => requirement.BeOfType<string>(value);

        // Assert
        act.Should().NotThrow();
    }

    public static IEnumerable<object[]> EmptyString_TestData =>
        new List<object[]>
        {
            new object[] { "" }
        };

    public static IEnumerable<object[]> NonEmptyString_TestData =>
        new List<object[]>
        {
            new object[] { "hello" },
            new object[] { "world" }
        };

    public static IEnumerable<object[]> EmptyCollection_TestData =>
        new List<object[]>
        {
            new object[] { new List<int>() },
            new object[] { new int[0] }
        };

    public static IEnumerable<object[]> NonEmptyCollection_TestData =>
        new List<object[]>
        {
            new object[] { new List<int> { 1, 2, 3 } },
            new object[] { new int[] { 1, 2, 3 } }
        };

    [Theory]
    [MemberData(nameof(EmptyString_TestData))]
    public void BeEmpty_String_ShouldNotThrowException_WhenStringIsEmpty(string value)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeEmpty(value);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(NonEmptyString_TestData))]
    public void BeEmpty_String_ShouldThrowException_WhenStringIsNotEmpty(string value)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeEmpty(value);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [MemberData(nameof(NonEmptyString_TestData))]
    public void NotBeEmpty_String_ShouldNotThrowException_WhenStringIsNotEmpty(string value)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.NotBeEmpty(value);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(EmptyString_TestData))]
    public void NotBeEmpty_String_ShouldThrowException_WhenStringIsEmpty(string value)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.NotBeEmpty(value);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [MemberData(nameof(EmptyCollection_TestData))]
    public void BeEmpty_Collection_ShouldNotThrowException_WhenCollectionIsEmpty(ICollection collection)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeEmpty(collection);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(NonEmptyCollection_TestData))]
    public void BeEmpty_Collection_ShouldThrowException_WhenCollectionIsNotEmpty(ICollection collection)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeEmpty(collection);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [MemberData(nameof(NonEmptyCollection_TestData))]
    public void NotBeEmpty_Collection_ShouldNotThrowException_WhenCollectionIsNotEmpty(ICollection collection)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.NotBeEmpty(collection);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(EmptyCollection_TestData))]
    public void NotBeEmpty_Collection_ShouldThrowException_WhenCollectionIsEmpty(ICollection collection)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.NotBeEmpty(collection);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    public static IEnumerable<object[]> Match_TestData =>
        new List<object[]>
        {
            new object[] { "abc123", @"^[a-z]+\d+$" },
            new object[] { "42", @"^\d+$" }
        };

    public static IEnumerable<object[]> NotMatch_TestData =>
        new List<object[]>
        {
            new object[] { "123abc", @"^[a-z]+\d+$" },
            new object[] { "abc", @"^\d+$" }
        };

    [Theory]
    [MemberData(nameof(Match_TestData))]
    public void Match_ShouldNotThrowException_WhenValueMatchesPattern(string value, string pattern)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.Match(value, pattern);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(NotMatch_TestData))]
    public void Match_ShouldThrowException_WhenValueDoesNotMatchPattern(string value, string pattern)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.Match(value, pattern);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [MemberData(nameof(NotMatch_TestData))]
    public void NotMatch_ShouldNotThrowException_WhenValueDoesNotMatchPattern(string value, string pattern)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.NotMatch(value, pattern);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(Match_TestData))]
    public void NotMatch_ShouldThrowException_WhenValueMatchesPattern(string value, string pattern)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.NotMatch(value, pattern);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    public static IEnumerable<object[]> BeGreaterThanOrEqualTo_TestData =>
        new List<object[]>
        {
            new object[] { 5, 3 },
            new object[] { 42, 42 },
            new object[] { 0L, -1L },
            new object[] { 7.5m, 7.5m },
            new object[] { 3.14, 3.0 },
            new object[] { new DateTime(2022, 1, 1), new DateTime(2021, 1, 1) },
        };

    public static IEnumerable<object[]> NotBeGreaterThanOrEqualTo_TestData =>
        new List<object[]>
        {
            new object[] { 1, 2 },
            new object[] { -1L, 0L },
            new object[] { 3.14m, 3.1415m },
            new object[] { 1.5, 1.6 },
            new object[] { new DateTime(2020, 1, 1), new DateTime(2021, 1, 1) },
        };

    [Theory]
    [MemberData(nameof(BeGreaterThanOrEqualTo_TestData))]
    public void BeGreaterThanOrEqualTo_ShouldNotThrowException_WhenValueIsGreaterThanOrEqualToCompareValue<T>(T value,
        T compareValue) where T : IComparable<T>
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeGreaterThanOrEqualTo(value, compareValue);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(NotBeGreaterThanOrEqualTo_TestData))]
    public void BeGreaterThanOrEqualTo_ShouldThrowException_WhenValueIsNotGreaterThanOrEqualToCompareValue<T>(T value,
        T compareValue) where T : IComparable<T>
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeGreaterThanOrEqualTo(value, compareValue);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    public static IEnumerable<object[]> BeLessThanOrEqualTo_TestData =>
        new List<object[]>
        {
            new object[] { 3, 5 },
            new object[] { 42, 42 },
            new object[] { -1L, 0L },
            new object[] { 7.5m, 7.5m },
            new object[] { 3.0, 3.14 },
            new object[] { new DateTime(2021, 1, 1), new DateTime(2022, 1, 1) },
        };

    public static IEnumerable<object[]> NotBeLessThanOrEqualTo_TestData =>
        new List<object[]>
        {
            new object[] { 2, 1 },
            new object[] { 0L, -1L },
            new object[] { 3.1415m, 3.14m },
            new object[] { 1.6, 1.5 },
            new object[] { new DateTime(2021, 1, 1), new DateTime(2020, 1, 1) },
        };

    [Theory]
    [MemberData(nameof(BeLessThanOrEqualTo_TestData))]
    public void BeLessThanOrEqualTo_ShouldNotThrowException_WhenValueIsLessThanOrEqualToCompareValue<T>(T value,
        T compareValue) where T : IComparable<T>
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeLessThanOrEqualTo(value, compareValue);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(NotBeLessThanOrEqualTo_TestData))]
    public void BeLessThanOrEqualTo_ShouldThrowException_WhenValueIsNotLessThanOrEqualToCompareValue<T>(T value,
        T compareValue) where T : IComparable<T>
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeLessThanOrEqualTo(value, compareValue);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }
    
    [Theory]
    [InlineData("https://example.com", UriKind.Absolute)]
    [InlineData("/path/to/resource", UriKind.Relative)]
    public void BeUrl_ShouldNotThrowException_WhenUrlIsValid(string url, UriKind uriKind)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeUrl(url, uriKind);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("invalid_url", UriKind.Absolute)]
    [InlineData("example.com", UriKind.Absolute)]
    public void BeUrl_ShouldThrowException_WhenUrlIsInvalid(string url, UriKind uriKind)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeUrl(url, uriKind);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    [Theory]
    [InlineData("test@example.com")]
    [InlineData("john.doe@example.co.uk")]
    public void BeEmail_ShouldNotThrowException_WhenEmailIsValid(string email)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeEmail(email);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("test.example.com")]
    [InlineData("john.doe@")]
    public void BeEmail_ShouldThrowException_WhenEmailIsInvalid(string email)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeEmail(email);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }

    public static IEnumerable<object[]> BeInRange_TestData =>
        new List<object[]>
        {
            new object[] { 3, 1, 5 },
            new object[] { 42, 42, 42 },
            new object[] { -1L, -5L, 0L },
            new object[] { 7.5m, 7.5m, 7.5m },
            new object[] { 3.14, 3.0, 3.1415 },
            new object[] { new DateTime(2021, 1, 1), new DateTime(2020, 1, 1), new DateTime(2022, 1, 1) },
        };

    [Theory]
    [MemberData(nameof(BeInRange_TestData))]
    public void BeInRange_ShouldNotThrowException_WhenValueIsInRange<T>(T value, T minValue, T maxValue) where T : IComparable<T>
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeInRange(value, minValue, maxValue);

        // Assert
        act.Should().NotThrow();
    }

    public static IEnumerable<object[]> NotBeInRange_TestData =>
        new List<object[]>
        {
            new object[] { 0, 1, 5 },
            new object[] { 43, 42, 42 },
            new object[] { -6L, -5L, 0L },
            new object[] { 7.6m, 7.5m, 7.5m },
            new object[] { 2.9, 3.0, 3.1415 },
            new object[] { new DateTime(2019, 1, 1), new DateTime(2020, 1, 1), new DateTime(2022, 1, 1) },
        };

    [Theory]
    [MemberData(nameof(NotBeInRange_TestData))]
    public void BeInRange_ShouldThrowException_WhenValueIsNotInRange<T>(T value, T minValue, T maxValue) where T : IComparable<T>
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.BeInRange(value, minValue, maxValue);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }
    
    public static IEnumerable<object[]> HaveMaxLength_TestData => new List<object[]>
    {
        new object[] { "short", 5 },
        new object[] { "exactly five", 12 },
        new object[] { "", 0 },
        new object[] { "Hello, World!", 20 }
    };

    [Theory]
    [MemberData(nameof(HaveMaxLength_TestData))]
    public void HaveMaxLength_ShouldNotThrowException_WhenTextLengthIsLessThanOrEqualToMaxLength(string text, int maxLength)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.HaveMaxLength(text, maxLength);

        // Assert
        act.Should().NotThrow();
    }

    public static IEnumerable<object[]> HaveMaxLength_Invalid_TestData => new List<object[]>
    {
        new object[] { "too long", 5 },
        new object[] { "exactly six", 5 },
        new object[] { "Hello, World!", 10 }
    };

    [Theory]
    [MemberData(nameof(HaveMaxLength_Invalid_TestData))]
    public void HaveMaxLength_ShouldThrowException_WhenTextLengthIsGreaterThanMaxLength(string text, int maxLength)
    {
        // Arrange
        var requirement = Requirement.To();

        // Act
        Action act = () => requirement.HaveMaxLength(text, maxLength);

        // Assert
        act.Should().Throw<RequirementFailedException>();
    }
}
