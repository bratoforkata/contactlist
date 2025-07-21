using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Services
{
    public class ContactRepository : IContactRepository
    {
        List<Contact> contacts = [
            new Contact("Test", "4411155"),
            new Contact("Kamil", "123555"),
            new Contact("Forka", "444455")
            ]; // make a list of contacts
        public List<Contact> Contacts { get { return contacts; } }

        // internal void Add(Contact contact)
        public void Add(Contact contact)
        {
            contacts.Add(contact);
        }

        // internal void RemoveAt(int i)
        public void RemoveAt(int i)
        {
            contacts.RemoveAt(i);
        }
    }

}
