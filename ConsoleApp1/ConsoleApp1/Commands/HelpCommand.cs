using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    public class HelpCommand : Command
    {
        CommandHandler commandHandler;

        public HelpCommand (CommandHandler commandHandler) : base(0) //
        {
            this.commandHandler = commandHandler;
        }

        public override string Name => "help";

        protected override void RunCommand(Queue<string> commandQueue)
        {
            foreach (var commandKey in commandHandler.GetCommandKeys(null))
            {
                Console.WriteLine(commandKey);
            }
        }
    }
}
