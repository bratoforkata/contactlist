using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class SentenceScoreRepository : ISentenceScoreRepository
    {
        private readonly IFileService _fileService;
        private const string fileName = "SentenceScore.txt";

        public SentenceScoreRepository(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Add(SentenceScore sentenceScore)
        {
            _fileService.SaveFile(fileName, ToLine(sentenceScore), append : true); // you can leave append, just true
        }

        public SentenceScore[] GetAll()
        {
            var lines = _fileService.LoadFile(fileName);

            return lines.Select(FromLine).ToArray();
            //1. load the file -- ok
            //2. use the lenght of the array to create equally long array of sentence score
            //3. loop through each loaded line and parse each line to a sentence score and add it to the array.
            //4. return the array of sentenceScore
        }
        private string ToLine(SentenceScore sentenceScore)
        {
            return string.Join("_",
                sentenceScore.SentenceId,
                sentenceScore.Username,
                sentenceScore.Score);
        }

        private SentenceScore FromLine(string line)
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
