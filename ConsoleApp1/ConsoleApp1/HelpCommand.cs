using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class HelpCommand : Command
    {
        Dictionary<string, Command> commands = new Dictionary<string, Command>();

        public HelpCommand (Dictionary<string, Command> commands) : base(0) //
        {
            this.commands = commands;
        }
        protected override void RunCommand(Queue<string> commandQueue)
        {
            foreach (KeyValuePair<string, Command> command in commands)
            {
                Console.WriteLine(command.Key);
            }
        }
        public override string ToString()
        {
            return "test";
        }
    }
}
