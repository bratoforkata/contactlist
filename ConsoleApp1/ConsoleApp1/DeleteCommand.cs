using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DeleteCommand : Command
    {
        private List<Contact> contacts;

        public DeleteCommand(List<Contact> contacts):base(1)
        {
            this.contacts = contacts;
        }
        protected override void RunCommand(Queue<string> commandQueue)
        {
            string deleteTerm = commandQueue.Dequeue();
            bool notFound = false; 

            for (int i = (contacts.Count) - (1); i >= 0; i--) //reversed for
            {
                if (string.Equals(deleteTerm, contacts[i].Name, StringComparison.InvariantCultureIgnoreCase))
                //if (contacts[i].Name.Contains(deleteTerm)) -- old version
                {
                    notFound = true; // new addition
                    Console.WriteLine(contacts[i].Name + " contact deleted");
                    contacts.RemoveAt(i);
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
