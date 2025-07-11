using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ExitCommand : Command
    {
        private ApplicationState state;
        public ExitCommand(ApplicationState state):base(0)
        {
            this.state = state;
        }
        protected override void RunCommand(Queue<string> commandQueue)
        {
            state.IsRunning = false;
        }
    }
}
