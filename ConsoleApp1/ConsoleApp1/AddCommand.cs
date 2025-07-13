using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AddCommand : Command
    {
        private List<Contact> contacts;

        public AddCommand(List<Contact> contacts):base(2)
        {
            this.contacts = contacts;
        }
        protected override void RunCommand(Queue<string> commandQueue)
        {
            bool isFound = false;
            string name = commandQueue.Dequeue();
            string number = commandQueue.Dequeue();

            //foreach (Contact contact in contacts) // it dies when testing :(
            for (int i = (contacts.Count) - (1); i >= 0; i--)
            {
                if (string.Equals(name, contacts[i].Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    isFound = true;
                    Console.WriteLine("contact exists");
                    break;
                }
            }
            if (isFound == false)
            {
                contacts.Add(new Contact(name, number));
                Console.WriteLine("added something");
            }
        }
    }
}
