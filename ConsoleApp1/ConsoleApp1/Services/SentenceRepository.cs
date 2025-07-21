using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class SentenceRepository : ISentenceRepository
    {
        private readonly FileService fileService;

        public SentenceRepository(FileService fileService)
        {
            this.fileService = fileService;
        }

        public Sentence GetRandomSentence()
        {
            // load the file
            var lines = fileService.LoadFile("sentences.txt");

            // select random line from it
            var line = lines[Random.Shared.Next(lines.Length)];

            // convert it to an instance of the sentence class
            var dataArray = line.Split('_', StringSplitOptions.RemoveEmptyEntries);
            var id = Guid.Parse(dataArray[0]);
            var text = dataArray[1];
            var sentence = new Sentence(text, id);

            // return it 
            return sentence;
        }
    }
}
