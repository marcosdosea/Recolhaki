using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class ServiceException : Exception
    {
        public ServiceException(string mensagem, Exception inner)
           : base(mensagem, inner)
        {

        }

        public ServiceException(string mensagem)
            : base(mensagem)
        {

        }
    }
}
