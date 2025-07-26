using ConsoleApp1.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IContactRepository : IRepository<Contact>
    {
        Contact[] Contacts { get; }
       
    }
}
