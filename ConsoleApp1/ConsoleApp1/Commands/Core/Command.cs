using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands.Core
{
    public abstract class Command : ICommand

    {
        private int requiredNumberCommands;

        public abstract string Name { get; } 

        public Guid Id { get; init; }
        public Guid? ParentId { get; init; }

        protected Command(int requiredCommands, Guid? parentId)
        {
            requiredNumberCommands = requiredCommands;
            Id = Guid.NewGuid();
            ParentId = parentId;
        }
        protected Command(int requiredCommands):this(requiredCommands, null)
        {
          
        }


        public void Execute(Queue<string> commandQueue)
        {
            if (Validate(commandQueue))
            {
                RunCommand(commandQueue);
            }
        }
        private bool Validate(Queue<string> commandQueue)
        {
            if (commandQueue.Count < requiredNumberCommands)
            {
                Console.WriteLine("incorrect number of parameters");
                return false;
            }
            return true;
        }
        protected abstract void RunCommand(Queue<string> commandQueue);

    }
}