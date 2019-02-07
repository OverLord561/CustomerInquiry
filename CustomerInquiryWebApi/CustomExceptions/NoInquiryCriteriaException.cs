using System;

namespace CustomExceptions
{
    public class NoInquiryCriteriaException : Exception
    {
        public NoInquiryCriteriaException()
        {
        }

        public NoInquiryCriteriaException(string message)
            : base(message)
        {
        }

        public NoInquiryCriteriaException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
