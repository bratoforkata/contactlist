using ConsoleApp1.Interfaces;
using ConsoleApp1.Services.Core;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class SentenceRepository : Repository<Sentence>, ISentenceRepository
    {
        private const string fileName = "sentences.txt";
        public SentenceRepository(IFileService fileService) : base(fileService, fileName)
        {
        }

        public Sentence GetRandomSentence()
        {
            // load the file
            var sentences = base.GetAll();

            // select random line from it
            var sentence = sentences[Random.Shared.Next(sentences.Length)];

            // return it 
            return sentence;
        }

        protected override Sentence FromLine(string line)
        {
            // convert it to an instance of the sentence class
            var dataArray = line.Split('_', StringSplitOptions.RemoveEmptyEntries);
            var id = Guid.Parse(dataArray[0]);
            var text = dataArray[1];
            var sentence = new Sentence(text, id);
            return sentence;
        }

        protected override string ToLine(Sentence item)
        {
            return string.Join("_",
                item.Id,
                item.Text);   
        }
    }
}
