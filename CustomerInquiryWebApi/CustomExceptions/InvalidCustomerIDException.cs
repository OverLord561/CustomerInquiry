using System;

namespace CustomExceptions
{
    class InvalidCustomerIDException : Exception
    {
        public InvalidCustomerIDException()
        {
        }

        public InvalidCustomerIDException(string message)
            : base(message)
        {
        }

        public InvalidCustomerIDException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
