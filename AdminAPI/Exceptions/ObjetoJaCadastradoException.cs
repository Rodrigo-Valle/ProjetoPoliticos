using System;

namespace AdminAPI.Exceptions
{
    public class ObjetoJaCadastradoException : Exception
    {
        public ObjetoJaCadastradoException(string msg) : base(msg)
        {
        }
    }
}