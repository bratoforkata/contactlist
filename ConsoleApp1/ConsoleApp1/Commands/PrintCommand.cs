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
        private readonly IFileService fileService;

        public PrintCommand(IContactRepository contactRepository, IFileService fileService) : base(0)
        {
            this.contactRepository = contactRepository;
            this.fileService = fileService;
        }

        public override string Name => "print";

        protected override void RunCommand(Queue<string> commandQueue)
        {
            foreach (Contact contact in contactRepository.Contacts)  // loop through the contacts!
            {
                contact.Print(); 
            }
        }
    }
}
