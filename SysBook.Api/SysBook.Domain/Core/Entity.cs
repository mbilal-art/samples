using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBook.Domain.Core
{
    public class Entity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public TimeOnly CreatedTime { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        public TimeOnly ModifiedTime { get; private set; }
        public string ModifiedByUserId { get; private set; }
    }
}
