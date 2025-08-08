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
    public class GamesFolderCommand : Command
    {
        private ICommandHandler handler;
        private ApplicationState state;

        public GamesFolderCommand(
            ICommandHandler handler, 
            ApplicationState state, 
            ISentenceRepository sentenceRepository,
            ISentenceScoreRepository scoreRepository)
            : base(0)

        {
            this.handler = handler;
            this.state = state;

            handler.Add(new NumbersGameCommand(state, Id));
            handler.Add(new RPSGameCommand(state, Id));
            handler.Add(new SentenceGameCommand(state, Id, sentenceRepository, scoreRepository));
            handler.Add(new SentenceScoreCommand(state, Id, sentenceRepository, scoreRepository));
            handler.Add(new BattleshipsGameCommand(state, Id));
            handler.Add(new TicTacToeGameCommand (state, Id));
            handler.Add(new HangDudGameCommand(state, Id));

        }

        public override string Name => "games";

        protected override void RunCommand(Queue<string> commandQueue)
        {
            Console.WriteLine(string.Join(", ", handler.GetCommandKeys(Id)));

            do
            {
                Console.WriteLine("Type a game:");
                commandQueue = state.GetCommandQueue();

            } while (commandQueue.Count == 0);

            var cmd = commandQueue.Dequeue();
            if (handler.ContainsKey(cmd, Id))
            {
                var command = handler.GetCommand(cmd, Id);
                command.Execute(commandQueue);
            }
        }
    }
}
