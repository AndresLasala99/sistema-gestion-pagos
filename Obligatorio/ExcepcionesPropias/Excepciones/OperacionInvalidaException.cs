using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias.Excepciones
{
    public class OperacionInvalidaException : Exception
    {
        public OperacionInvalidaException() { }

        public OperacionInvalidaException(string message) : base(message) { }

        public OperacionInvalidaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
