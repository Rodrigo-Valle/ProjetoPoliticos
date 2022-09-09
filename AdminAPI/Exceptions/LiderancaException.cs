using System;

namespace AdminAPI.Exceptions
{
    public class LiderancaException : Exception
    {
        public LiderancaException(string message) : base(message)
        {
        }
    }
}