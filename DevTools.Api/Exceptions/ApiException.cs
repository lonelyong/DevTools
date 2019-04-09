using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException() : base()
        {

        }

        public ApiException(string msg) : base(msg)
        {

        }

        public ApiException(string msg, Exception inner) : base(msg, inner)
        {

        }
    }
}
