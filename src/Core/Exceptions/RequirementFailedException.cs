namespace TRRequirement.Core.Exceptions;

internal class RequirementFailedException : Exception
{
    public RequirementFailedException(string message) : base(message)
    {
    }
}