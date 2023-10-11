using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    internal  class App
    {
        private readonly ContactBookServices _contactBookServices;
        public App(ContactBookServices contactBookServices)
        {
            _contactBookServices = contactBookServices;
        }
        public  void AppContactBook()
        {
            
        }
    }
}
