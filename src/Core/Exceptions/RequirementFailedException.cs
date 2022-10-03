using System;
using System.Runtime.Serialization;

namespace TRRequirement.Core.Exceptions
{
    [Serializable]
    public class RequirementFailedException : Exception
    {
        public RequirementFailedException(string message) : base(message)
        {
        }

        public RequirementFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}