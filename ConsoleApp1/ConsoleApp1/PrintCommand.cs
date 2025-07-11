using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PrintCommand : Command
    {
        private List<Contact> contacts;

        public PrintCommand(List<Contact> contacts):base(0)
        {
            this.contacts = contacts;
        }

        protected override void RunCommand(Queue<string> commandQueue)
        {
            foreach (Contact contact in contacts)  // loop through the contacts!
            {
                // Console.WriteLine("Contacts:" + contact.Name + ", Phone: " + contact.Number); //the same
                contact.Print(); // as this
            }
        }
    }
}
