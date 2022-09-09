using System;

namespace AdminAPI.Exceptions
{
    public class ProcessoNaoPermitidoException : Exception
    {
        public ProcessoNaoPermitidoException(string Message) : base(Message)
        {
        }
    }
}