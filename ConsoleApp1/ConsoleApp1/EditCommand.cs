using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EditCommand : Command
    {
        private List<Contact> _contacts; // variables member
        private ApplicationState _applicationState; // variables

        public EditCommand(List<Contact> contacts, ApplicationState applicationState):base(1)
        {
            _contacts = contacts;
            _applicationState = applicationState;
        } //constructor 
        protected override void RunCommand(Queue<string> commandQueue)
        {

            string editTerm = commandQueue.Dequeue();
            bool notfound = false;

            for (int i = _contacts.Count - 1; i >= 0; i--) //reversed for
            {
                if (string.Equals(editTerm, _contacts[i].Name, StringComparison.InvariantCultureIgnoreCase))
                //if (contacts[i].Name.Contains(editTerm))
                {
                    Console.WriteLine("enter new name:");
                    string newName = _applicationState.GetNextLine();

                    _contacts[i].Name = newName; // great discovery im proud

                    Console.WriteLine("enter new phone number:");
                    string newNumber = _applicationState.GetNextLine();

                    _contacts[i].Number = newNumber;

                    Console.WriteLine("contact updated");
                    notfound = true;

                    break;
                }
            }
            if (!notfound)
            {
                Console.WriteLine("No contact found");
            }
        } //method
    }
}
