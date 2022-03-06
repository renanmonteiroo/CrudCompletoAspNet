using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuCrudCompleto.Servicos.Exceptions
{
    public class IntegridadeException :ApplicationException
    {
        public IntegridadeException(string message) : base(message)
        {

        }
    }
}
