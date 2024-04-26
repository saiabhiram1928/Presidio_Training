using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary.Exceptions
{
    public class NoItemWithGiveIdException : Exception
    {
        string message;
        public NoItemWithGiveIdException(string type)
        {
            message = $"{type} with the given Id is not present";
        }
        public override string Message => message;
    }
}
