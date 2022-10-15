using System.Collections;

namespace TheNoobs.Requirements.Abstractions;

public interface IRequirement
{
    void NotBeNull(object? obj, Func<Exception>? createException = null);
    void BeNull(object? obj, Func<Exception>? createException = null);
    void BeTrue(bool condition, Func<Exception>? createException = null);
    void BeFalse(bool condition, Func<Exception>? createException = null);
    void BeEmpty(string text, Func<Exception>? createException = null);
    void BeEmpty(ICollection collection, Func<Exception>? createException = null);
    void NotBeEmpty(string text, Func<Exception>? createException = null);
    void NotBeEmpty(ICollection collection, Func<Exception>? createException = null);
    void Match(string value, string pattern, Func<Exception>? createException = null);
    void NotMatch(string value, string pattern, Func<Exception>? createException = null);
    void BeGreaterThanOrEqualTo(int value, int compareValue, Func<Exception>? createException = null);
    void BeGreaterThanOrEqualTo(long value, long compareValue, Func<Exception>? createException = null);

    void BeGreaterThanOrEqualTo(decimal value, decimal compareValue,
        Func<Exception>? createException = null);

    void BeGreaterThanOrEqualTo(double value, double compareValue, Func<Exception>? createException = null);

    void BeGreaterThanOrEqualTo(DateTime value, DateTime compareValue,
        Func<Exception>? createException = null);

    void BeLessThanOrEqualTo(int value, int compareValue, Func<Exception>? createException = null);
    void BeLessThanOrEqualTo(long value, long compareValue, Func<Exception>? createException = null);
    void BeLessThanOrEqualTo(decimal value, decimal compareValue, Func<Exception>? createException = null);
    void BeLessThanOrEqualTo(double value, double compareValue, Func<Exception>? createException = null);

    void BeLessThanOrEqualTo(DateTime value, DateTime compareValue,
        Func<Exception>? createException = null);
}