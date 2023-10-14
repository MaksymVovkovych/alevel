using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class MutexException : Exception
    {
        public MutexException() { }
        public MutexException(string message) : base(message) { }
    }
}
