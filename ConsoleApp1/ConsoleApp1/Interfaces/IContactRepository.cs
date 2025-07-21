using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> Contacts { get; }
        void Add(Contact contact);
        void RemoveAt(int i);
    }
}
