using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    public class SearchCommand : Command
    {
        private ContactRepository contactRepository;

        public SearchCommand(ContactRepository contactRepository):base(1)
        {
            this.contactRepository = contactRepository;
        }
        protected override void RunCommand(Queue<string> commandQueue)
        {
            string searchTerm = commandQueue.Dequeue(); // define searchTerm - get the text written on the console
            bool isFound = false;

            foreach (Contact contact in contactRepository.Contacts) // loops through contacts 
            {
                if (contact.Name.Contains(searchTerm)) // check if contact name contains the text entered
                {
                    isFound = true;
                    contact.Print();
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no contact found");
            }
        }
    }
}
