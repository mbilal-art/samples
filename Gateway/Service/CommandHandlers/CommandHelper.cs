using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CommandHandlers
{
    public class CommandHelper
    {
        public static string GenerateApprovalCode()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            if (r.Distinct().Count() == 1)
            {
                r = GenerateApprovalCode();
            }
            return r;
        }
    }
}
