using System.Collections;

public interface IRequirement
{
    void NotBeNull(object? obj, Func<Exception>? createException = null);
    void BeNull(object? obj, Func<Exception>? createException = null);
    void BeTrue(bool condition, Func<Exception>? createException = null);
    void BeFalse(bool condition, Func<Exception>? createException = null);
    void BeEmpty(string text, Func<Exception>? createException = null);
    void NotBeEmpty(string text, Func<Exception>? createException = null);
    void BeEmpty(ICollection collection, Func<Exception>? createException = null);
    void NotBeEmpty(ICollection collection, Func<Exception>? createException = null);
    void BeOfType<T>(object? obj, Func<Exception>? createException = null);
    void Match(string value, string pattern, Func<Exception>? createException = null);
    void NotMatch(string value, string pattern, Func<Exception>? createException = null);
    void BeGreaterThanOrEqualTo<T>(T value, T compareValue, Func<Exception>? createException = null)
    where T: IComparable<T>;
    void BeLessThanOrEqualTo<T>(T value, T compareValue, Func<Exception>? createException = null)
    where T: IComparable<T>;
    void BeUrl(string url, UriKind uriKind = UriKind.RelativeOrAbsolute, Func<Exception>? createException = null);
    void BeEmail(string email, Func<Exception>? createException = null);
    void BeInRange<T>(T value, T minValue, T maxValue, Func<Exception>? createException = null)
    where T: IComparable<T>;
}
