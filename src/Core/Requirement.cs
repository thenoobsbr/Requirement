using System;
using System.Collections;
using System.Text.RegularExpressions;

using TRRequirement.Core.Exceptions;

namespace TRRequirement.Core
{
    public static class Requirement
    {
        public static void ToNotBeNull(object? obj, Func<Exception>? createException = null)
        {
            if (obj is string text && !string.IsNullOrWhiteSpace(text)
                || obj != null)
            {
                return;
            }

            throw createException?.Invoke() ?? new RequirementFailedException("The object should not be null");
        }

        public static void ToBeNull(object? obj, Func<Exception>? createException = null)
        {
            if (obj is string text && string.IsNullOrWhiteSpace(text)
                || obj is null)
            {
                return;
            }

            throw createException?.Invoke() ?? new RequirementFailedException("The object should be null");
        }

        public static void ToBeTrue(bool condition, Func<Exception>? createException = null)
        {
            if (condition)
            {
                return;
            }

            throw createException?.Invoke() ?? new RequirementFailedException("The condition should be true");
        }

        public static void ToBeFalse(bool condition, Func<Exception>? createException = null)
        {
            if (!condition)
            {
                return;
            }

            throw createException?.Invoke() ?? new RequirementFailedException("The condition should be false");
        }

        public static void ToBeEmpty(string text, Func<Exception>? createException = null)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            throw createException?.Invoke() ?? new RequirementFailedException("The text should be empty");
        }

        public static void ToNotBeEmpty(string text, Func<Exception>? createException = null)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            throw createException?.Invoke() ?? new RequirementFailedException("The text should not be empty");
        }

        public static void ToBeEmpty(ICollection collection, Func<Exception>? createException = null)
        {
            if (collection.Count == 0)
            {
                return;
            }

            throw createException?.Invoke() ?? new RequirementFailedException("The collection should be empty");
        }

        public static void ToNotBeEmpty(ICollection collection, Func<Exception>? createException = null)
        {
            if (collection.Count > 0)
            {
                return;
            }

            throw createException?.Invoke() ?? new RequirementFailedException("The collection should not be empty");
        }

        public static void ToMatch(string value, string pattern, Func<Exception>? createException)
        {
            if (Regex.IsMatch(value, pattern, RegexOptions.Compiled))
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should match the pattern {pattern}");
        }

        public static void ToNotMatch(string value, string pattern, Func<Exception>? createException)
        {
            if (!Regex.IsMatch(value, pattern, RegexOptions.Compiled))
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should not match the pattern {pattern}");
        }

        public static void ToBeGreaterThanOrEqualTo(int value, int compareValue, Func<Exception>? createException)
        {
            if (value >= compareValue)
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should be greater than or equal to {compareValue}");
        }

        public static void ToBeGreaterThanOrEqualTo(long value, long compareValue, Func<Exception>? createException)
        {
            if (value >= compareValue)
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should be greater than or equal to {compareValue}");
        }

        public static void ToBeGreaterThanOrEqualTo(decimal value, decimal compareValue,
            Func<Exception>? createException)
        {
            if (value >= compareValue)
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should be greater than or equal to {compareValue}");
        }

        public static void ToBeGreaterThanOrEqualTo(double value, double compareValue, Func<Exception>? createException)
        {
            if (value >= compareValue)
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should be greater than or equal to {compareValue}");
        }

        public static void ToBeGreaterThanOrEqualTo(DateTime value, DateTime compareValue,
            Func<Exception>? createException)
        {
            if (value >= compareValue)
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should be greater than or equal to {compareValue}");
        }

        public static void ToBeLessThanOrEqualTo(int value, int compareValue, Func<Exception>? createException)
        {
            if (value <= compareValue)
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should be less than or equal to {compareValue}");
        }

        public static void ToBeLessThanOrEqualTo(long value, long compareValue, Func<Exception>? createException)
        {
            if (value <= compareValue)
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should be less than or equal to {compareValue}");
        }

        public static void ToBeLessThanOrEqualTo(decimal value, decimal compareValue, Func<Exception>? createException)
        {
            if (value <= compareValue)
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should be less than or equal to {compareValue}");
        }

        public static void ToBeLessThanOrEqualTo(double value, double compareValue, Func<Exception>? createException)
        {
            if (value <= compareValue)
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should be less than or equal to {compareValue}");
        }

        public static void ToBeLessThanOrEqualTo(DateTime value, DateTime compareValue,
            Func<Exception>? createException)
        {
            if (value <= compareValue)
            {
                return;
            }

            throw createException?.Invoke() ??
                  new RequirementFailedException($"The \"{value}\" should be less than or equal to {compareValue}");
        }
    }
}