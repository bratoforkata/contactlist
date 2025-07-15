using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class ContactRepository
    {
        List<Contact> contacts = [
            new Contact("Test", "4411155"),
            new Contact("Kamil", "123555"),
            new Contact("Forka", "444455")
            ]; // make a list of contacts
        public List<Contact> Contacts {  get { return contacts; } }

        internal void Add(Contact contact)
        {
           contacts.Add(contact);
        }

        internal void RemoveAt(int i)
        {
            contacts.RemoveAt(i);
        }
    }

}
