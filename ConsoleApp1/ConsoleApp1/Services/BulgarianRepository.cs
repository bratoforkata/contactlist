using ConsoleApp1.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Services
{
    public class BulgarianRepository
    {
        private readonly IFileService fileService;
        private const string fileName = "Bulgarian.txt";

        public BulgarianRepository(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public void Add(string word)
        {
            fileService.SaveFile(fileName, "," + word , append: true);
        }

        public List<string> GetAll()
        {
            var lines = fileService.LoadFile(fileName);
            return lines
                .SelectMany(line => line.Split(','))
                .Select(word => word.Trim())
                .Where(word => !string.IsNullOrWhiteSpace(word))
                .ToList();
        }
    }
}
