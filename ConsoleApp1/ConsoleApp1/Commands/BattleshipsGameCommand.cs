using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;

namespace ConsoleApp1.Commands
{
    public class BattleshipsGameCommand : Command
    {
        private ApplicationState state;
        
        public BattleshipsGameCommand(ApplicationState state, Guid parentId):base(0, parentId)
        {
            this.state = state;
        }

        public override string Name => "battleships";

        protected override void RunCommand(Queue<string> commandQueue)
        {
            Console.WriteLine("Welcome to Battheships yo!");

        }
    }
}
