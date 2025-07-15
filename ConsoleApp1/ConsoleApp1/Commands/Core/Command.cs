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
        protected Command(int requiredCommands)
        {
            requiredNumberCommands = requiredCommands;
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