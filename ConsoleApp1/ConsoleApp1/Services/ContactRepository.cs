using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interfaces;
using ConsoleApp1.Services.Core;

namespace ConsoleApp1.Services
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private const string fileName = "Contacts.txt";

        public Contact[] Contacts => GetAll();

        public ContactRepository(IFileService fileService) : base (fileService, fileName) 
        {

        }


        protected override string ToLine(Contact contact)
        {
            return string.Join("_", contact.Name, contact.Number);
        }

        protected override Contact FromLine(string line)
        {
            var split = line.Split('_');
            return new Contact(split[0], split[1]);
        }
    }
}
