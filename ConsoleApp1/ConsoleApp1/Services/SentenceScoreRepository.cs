using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class SentenceScoreRepository : ISentenceScoreRepository
    {
        private readonly IFileService _fileService;

        public SentenceScoreRepository(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Add(SentenceScore sentenceScore)
        {
            var line = string.Join(
                "_",
                sentenceScore.SentenceId,
                sentenceScore.Username,
                sentenceScore.Score);
            _fileService.SaveFile("SentenceScore.txt", line, append : true); // you can leave append, just true
        }

        public SentenceScore[] GetScores()
        {
            //1. load the file
            //2. use the lenght of the array to create equally long array of sentence score
            //3. loop through each loaded line and parse each line to a sentence score and add it to the array.
            //4. return the array of sentenceScores
            throw new NotImplementedException(); // homework here 
        }
    }
}
