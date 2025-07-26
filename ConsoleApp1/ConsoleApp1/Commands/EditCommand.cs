using ConsoleApp1.Commands.Core;
using ConsoleApp1.Interfaces;
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
        private IContactRepository _contactRepository; // variables member
        private ApplicationState _applicationState; // variables

        public EditCommand(IContactRepository contactRepository, ApplicationState applicationState):base(1)
        {
            _contactRepository = contactRepository;
            _applicationState = applicationState;
        } //constructor 

        public override string Name => "edit";

        protected override void RunCommand(Queue<string> commandQueue)
        {
            string editTerm = commandQueue.Dequeue();
            bool notfound = false;
            var contacts = _contactRepository.Contacts;

            for (int i = contacts.Length - 1; i >= 0; i--) //reversed for
            {
                if (string.Equals(editTerm, contacts[i].Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("enter new name:");
                    string newName = _applicationState.GetNextLine();

                    Console.WriteLine("enter new phone number:");
                    string newNumber = _applicationState.GetNextLine();

                    Contact toEdit = contacts[i];
                    toEdit.Name = newName;
                    toEdit.Number = newNumber;

                    _contactRepository.ReplaceAt(i, toEdit);

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
