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
    public class SentenceScoreCommand : Command
    {
        private ApplicationState state;
        private readonly ISentenceRepository sentenceRepository;
        private readonly ISentenceScoreRepository scoreRepository;

        public SentenceScoreCommand(
            ApplicationState state,
            Guid parentId,
            ISentenceRepository sentenceRepository,
            ISentenceScoreRepository scoreRepository)
            : base(0, parentId)
        {
            this.state = state;
            this.sentenceRepository = sentenceRepository;
            this.scoreRepository = scoreRepository;
        }

        public override string Name => "sentencesScore";

        protected override void RunCommand(Queue<string> commandQueue)
        {
            var scores = scoreRepository.GetAll();

            foreach (var score in scores)
            {
                Console.WriteLine($"SentenceId: {score.SentenceId}, User: {score.Username}, Score: {score.Score}");
            }
        }
    }
}
