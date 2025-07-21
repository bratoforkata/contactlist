using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IFileService
    {
        public void SaveFile(string fileName, string data, bool append);
        string[] LoadFile(string fileName);
    }
}
