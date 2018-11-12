using System;

namespace Expm.Core.Exceptions
{
    public class NoEntityException : Exception
    {
        public NoEntityException() : base()
        {   
        }
        public NoEntityException(string message) : base(message)
        {   
        }
        public NoEntityException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}