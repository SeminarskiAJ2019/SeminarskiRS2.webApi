using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message):
            base(message)
        {

        }
    }
}
