using System;

namespace KQLGenerator.Exceptions
{
    public class ManagedPropertyNullOrEmptyException : Exception
    {
        public ManagedPropertyNullOrEmptyException(String message) : base(message)
        {
        }
    }
}
