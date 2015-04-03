using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo.Exceptions
{
    public class ImageResolutionLessThanGridResolutionException : Exception
    {
        public ImageResolutionLessThanGridResolutionException() : 
            base("The Image resolution is less than the grid resolution") { 
        }
    }
}
