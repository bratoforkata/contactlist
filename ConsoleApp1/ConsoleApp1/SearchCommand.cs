using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SearchCommand : Command
    {
        private List<Contact> contacts;

        public SearchCommand(List<Contact> contacts):base(1)
        {
            this.contacts = contacts;
        }
        protected override void RunCommand(Queue<string> commandQueue)
        {
            string searchTerm = commandQueue.Dequeue(); // define searchTerm - get the text written on the console
            bool isFound = false;

            foreach (Contact contact in contacts) // loops through contacts 
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
