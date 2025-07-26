using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using ConsoleApp1.Services.Core;

namespace ConsoleApp1.Services
{
    public class SentenceScoreRepository : Repository<SentenceScore>, ISentenceScoreRepository
    {
        private const string fileName = "SentenceScore.txt";

        public SentenceScore[] SentenceScore => GetAll();

        public SentenceScoreRepository(IFileService fileService) :base (fileService, fileName)
        {
        }

           protected override string ToLine(SentenceScore sentenceScore)
        {
            return string.Join("_",
                sentenceScore.SentenceId,
                sentenceScore.Username,
                sentenceScore.Score);
        }
        protected override SentenceScore FromLine(string line)
        {
            var split = line.Split('_');
            return new SentenceScore
            {
                SentenceId = Guid.Parse(split[0]),
                Username = split[1],
                Score = float.Parse(split[2])
            };
        }
    }
}
