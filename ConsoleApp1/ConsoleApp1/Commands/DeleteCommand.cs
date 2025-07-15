using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    public class DeleteCommand : Command
    {
        private ContactRepository contactRepository;

        public DeleteCommand(ContactRepository contactRepository):base(1)
        {
            this.contactRepository = contactRepository;
        }
        protected override void RunCommand(Queue<string> commandQueue)
        {
            string deleteTerm = commandQueue.Dequeue();
            bool notFound = false; 

            for (int i = contactRepository.Contacts.Count - 1; i >= 0; i--) //reversed for
            {
                if (string.Equals(deleteTerm, contactRepository.Contacts[i].Name, StringComparison.InvariantCultureIgnoreCase))
                //if (contacts[i].Name.Contains(deleteTerm)) -- old version
                {
                    notFound = true; // new addition
                    Console.WriteLine(contactRepository.Contacts[i].Name + " contact deleted");
                    contactRepository.RemoveAt(i);
                    break;
                }
            }
            if (!notFound) //tell the mistake so we have a laugh
                           //(if was in the for loop so it was printing 5 times ffs
            {
                Console.WriteLine("no contact found/deleted");   //this is new add for homework
            }
        }
    }
}
