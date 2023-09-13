using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame.Exceptions
{
    public class LifeException : Exception
    {
        public LifeException(string message) : base(message) { }
    }
}
