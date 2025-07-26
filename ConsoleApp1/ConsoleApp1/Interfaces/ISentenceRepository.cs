using ConsoleApp1.Interfaces.Core;
using ConsoleApp1.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface ISentenceRepository : IRepository<Sentence>
    {
        Sentence GetRandomSentence();
    }
}
