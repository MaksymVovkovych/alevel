using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class Contact
    {
        public required string Name { get; set; }
        public string? Surname { get; set; }
        public required uint Number { get; set; }
    }
}
