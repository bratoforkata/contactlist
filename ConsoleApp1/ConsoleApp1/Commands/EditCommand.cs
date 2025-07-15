using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    public class EditCommand : Command
    {
        private ContactRepository _contactRepository; // variables member
        private ApplicationState _applicationState; // variables

        public EditCommand(ContactRepository contactRepository, ApplicationState applicationState):base(1)
        {
            _contactRepository = contactRepository;
            _applicationState = applicationState;
        } //constructor 
        protected override void RunCommand(Queue<string> commandQueue)
        {

            string editTerm = commandQueue.Dequeue();
            bool notfound = false;

            for (int i = _contactRepository.Contacts.Count - 1; i >= 0; i--) //reversed for
            {
                if (string.Equals(editTerm, _contactRepository.Contacts[i].Name, StringComparison.InvariantCultureIgnoreCase))
                //if (contacts[i].Name.Contains(editTerm))
                {
                    Console.WriteLine("enter new name:");
                    string newName = _applicationState.GetNextLine();

                    _contactRepository.Contacts[i].Name = newName; // great discovery im proud

                    Console.WriteLine("enter new phone number:");
                    string newNumber = _applicationState.GetNextLine();

                    _contactRepository.Contacts[i].Number = newNumber;

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
