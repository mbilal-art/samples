using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class TransactionCommandResult
    {
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public long ApprovalCode { get; set; }
        public DateTime DateTime { get; set; } 
    }
}
