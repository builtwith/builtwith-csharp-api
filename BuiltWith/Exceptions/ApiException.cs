using System;

namespace BuiltWith.Exceptions
{
    public class ApiException : BuiltWithException
    {
        public int? StatusCode { get; }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public ApiException(string message, Exception innerException) : base(message, innerException) { }
    }
}
