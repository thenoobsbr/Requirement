using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TheNoobs.Requirements.Exceptions;

public class Requirement : IRequirement
{
    private static readonly IRequirement _instance = new Requirement();
    private readonly Func<Exception>? _createException;

    private Requirement(Func<Exception>? createException = null)
    {
        _createException = createException;
    }

    public static IRequirement To() => _instance;

    public static IRequirement To(Func<Exception> createException)
    {
        return new Requirement(createException);
    }

    public void NotBeNull(object? obj, Func<Exception>? createException = null)
    {
        if (obj is not null)
        {
            return;
        }

        throw CreateException(createException, "Object is null");
    }

    public void BeNull(object? obj, Func<Exception>? createException = null)
    {
        if (obj is null)
        {
            return;
        }

        throw CreateException(createException, "Object is not null");
    }

    public void BeTrue(bool condition, Func<Exception>? createException = null)
    {
        if (condition)
        {
            return;
        }

        throw CreateException(createException, "Condition is false");
    }

    public void BeFalse(bool condition, Func<Exception>? createException = null)
    {
        if (!condition)
        {
            return;
        }

        throw CreateException(createException, "Condition is true");
    }

    public void BeEmpty(string text, Func<Exception>? createException = null)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        throw CreateException(createException, "Text is not empty");
    }

    public void BeEmpty(ICollection collection, Func<Exception>? createException = null)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        if (collection.Count == 0)
        {
            return;
        }

        throw CreateException(createException, "Collection is not empty");
    }

    public void NotBeEmpty(string text, Func<Exception>? createException = null)
    {
        if (!string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        throw CreateException(createException, "Text is empty");
    }

    public void NotBeEmpty(ICollection collection, Func<Exception>? createException = null)
    {
        if (collection.Count > 0)
        {
            return;
        }

        throw CreateException(createException, "Collection is empty");
    }

    public void BeOfType<T>(object? obj, Func<Exception>? createException = null)
    {
        switch (obj)
        {
            case null:
                throw new ArgumentNullException(nameof(obj));
            case T:
                return;
            default:
                throw CreateException(createException, $"Object is not of type {typeof(T).Name}");
        }
    }

    public void Match(string value, string pattern, Func<Exception>? createException = null)
    {
        if (Regex.IsMatch(value, pattern))
        {
            return;
        }

        throw CreateException(createException, $"Value {value} does not match pattern {pattern}");
    }

    public void NotMatch(string value, string pattern, Func<Exception>? createException = null)
    {
        if (!Regex.IsMatch(value, pattern))
        {
            return;
        }

        throw CreateException(createException, $"Value {value} matches pattern {pattern}");
    }
    
    public void BeGreaterThanOrEqualTo<T>(T value, T compareValue, Func<Exception>? createException = null)
    where T : IComparable<T>
    {
        if (value.CompareTo(compareValue) >= 0)
        {
            return;
        }

        throw CreateException(createException, $"Value {value} is not greater than or equal to {compareValue}");
    }

    public void BeLessThanOrEqualTo<T>(T value, T compareValue, Func<Exception>? createException = null)
    where T : IComparable<T>
    {
        if (value.CompareTo(compareValue) <= 0)
        {
            return;
        }

        throw CreateException(createException, $"Value {value} is not less than or equal to {compareValue}");
    }

    public void BeUrl(string url, UriKind uriKind = UriKind.RelativeOrAbsolute, Func<Exception>? createException = null)
    {
        if (Uri.TryCreate(url, uriKind, out Uri uri) && uri != null)
        {
            return;
        }

        throw CreateException(createException, $"Value {url} is not a valid url");
    }

    public void BeEmail(string email, Func<Exception>? createException = null)
    {
        if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            return;
        }

        throw CreateException(createException, $"Value {email} is not a valid email address");
    }

    public void BeInRange<T>(T value, T minValue, T maxValue, Func<Exception>? createException = null) where T : IComparable<T>
    {
        if (value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0)
        {
            return;
        }

        throw CreateException(createException, $"Value {value} is not in range {minValue} - {maxValue}");
    }

    private Exception CreateException(Func<Exception>? createException = null,
        string? message = "Requirement \"{0}\" was not fulfilled",
        [CallerMemberName] string? requirement = null)
    {
        return createException?.Invoke()
               ?? _createException?.Invoke()
               ?? new RequirementFailedException(string.Format(message, requirement));
    }
}
