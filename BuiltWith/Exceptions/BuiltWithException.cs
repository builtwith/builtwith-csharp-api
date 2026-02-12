using System;

namespace BuiltWith.Exceptions
{
    public class BuiltWithException : Exception
    {
        public BuiltWithException() : base() { }

        public BuiltWithException(string message) : base(message) { }

        public BuiltWithException(string message, Exception innerException) : base(message, innerException) { }
    }
}
