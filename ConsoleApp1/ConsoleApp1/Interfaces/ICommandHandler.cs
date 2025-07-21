using ConsoleApp1.Commands.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface ICommandHandler
    {
        bool ContainsKey(string command, Guid? parentId);
        Command GetCommand(string command, Guid? parentId);
        IEnumerable<string> GetCommandKeys(Guid? parentId);
        void Add(Command command);
    }
}
