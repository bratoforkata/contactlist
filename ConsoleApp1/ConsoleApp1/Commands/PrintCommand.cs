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
    public class PrintCommand : Command
    {
        private IContactRepository contactRepository;

        public PrintCommand(IContactRepository contactRepository):base(0)
        {
            this.contactRepository = contactRepository;
        }

        public override string Name => "print";

        protected override void RunCommand(Queue<string> commandQueue)
        {
            foreach (Contact contact in contactRepository.Contacts)  // loop through the contacts!
            {
                // Console.WriteLine("Contacts:" + contact.Name + ", Phone: " + contact.Number); //the same
                contact.Print(); // as this
            }
        }
    }
}
