using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    public class AddCommand : Command
    {
        private ContactRepository contactRepository;

        public AddCommand(ContactRepository contactRepository):base(2)
        {
            this.contactRepository = contactRepository;
        }
        protected override void RunCommand(Queue<string> commandQueue)
        {
            bool isFound = false;
            string name = commandQueue.Dequeue();
            string number = commandQueue.Dequeue();

            //foreach (Contact contact in contacts) // it dies when testing :(
            for (int i = contactRepository.Contacts.Count - 1; i >= 0; i--)
            {
                if (string.Equals(name, contactRepository.Contacts[i].Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    isFound = true;
                    Console.WriteLine("contact exists");
                    break;
                }
            }
            if (isFound == false)
            {
                contactRepository.Add(new Contact(name, number));
                Console.WriteLine("added something");
            }
        }
    }
}
