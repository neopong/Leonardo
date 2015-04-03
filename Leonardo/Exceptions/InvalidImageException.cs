using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo.Exceptions
{
    public class InvalidImageException : Exception
    {
        public InvalidImageException() : base ("Image is invalid"){ }
    }
}
