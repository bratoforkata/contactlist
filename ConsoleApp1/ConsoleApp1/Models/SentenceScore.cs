using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class SentenceScore
    {
        public required Guid SentenceId { get; set; }
        public required float Score { get; set; }
        public required string Username { get; set; }
    }
}
