using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1.Services.Core

{
    public abstract class Repository<T>
    {
        private readonly IFileService _fileService;
        private readonly string fileName;

        protected Repository(IFileService fileService, string fileName)
        {
            _fileService = fileService;
            this.fileName = fileName;
        }

        public void Add(T item)
        {
            _fileService.SaveFile(fileName, ToLine(item), true);
        }

        public void RemoveAt(int i)
        {
            var data = GetAll();
            data.RemoveAt(i);
            Save(data);
        }

        public List<T> GetAll()
        {
            var lines = _fileService.LoadFile(fileName);

            return lines
                .Select(FromLine)
                .ToList();
        }
        private void Save(IEnumerable<T> data) // we can use that for the editting of contacts
        {
            _fileService.SaveFile(
             fileName,
             string.Join(Environment.NewLine, data.Select(ToLine)),
             false);
        }
        protected abstract string ToLine(T contact);
        protected abstract T FromLine(string line);
    }
}
