using System;

namespace KQLGenerator.Exceptions
{
    public class ValueNullOrEmptyException : Exception
    {
        public ValueNullOrEmptyException(String message)
            : base(message)
        {
        }
    }
}
