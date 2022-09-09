using System;

namespace AdminAPI.Exceptions
{
    public class PoliticoComProjetosOuProcessoExcpetion : Exception
    {
        public PoliticoComProjetosOuProcessoExcpetion(string message) : base(message)
        {
        }
    }
}