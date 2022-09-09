using System;

namespace AdminAPI.Exceptions
{
    public class ObjetoNaoLocalizadoException : Exception
    {
        public ObjetoNaoLocalizadoException(string msg) : base(msg)
        {
        }
    }
}