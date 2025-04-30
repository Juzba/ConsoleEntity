using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEntity.Models
{
    public class IssDbPosition
    {
        public int ID { get; set; }
        public required Iss_Position Iss_Position { get; set; }
        public required string Message { get; set; }
        public long Timestamp { get; set; }
    }
}
