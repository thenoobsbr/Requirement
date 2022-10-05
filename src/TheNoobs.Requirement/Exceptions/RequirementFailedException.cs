using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace TheNoobs.Requirement.Exceptions;

[Serializable]
public class RequirementFailedException : Exception
{
    public RequirementFailedException(string message) : base(message)
    {
    }

    [ExcludeFromCodeCoverage]
    protected RequirementFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}