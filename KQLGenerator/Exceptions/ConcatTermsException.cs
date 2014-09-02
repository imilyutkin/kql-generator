using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQLGenerator.Exceptions
{
    public class ConcatTermsException : Exception
    {
        public ConcatTermsException(String message) : base(message)
        {
        }
    }
}
