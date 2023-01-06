using Domain.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CommandHandlers
{
    public class TransactionCommandHandler : IRequestHandler<TransactionCommand, TransactionCommandResult>
    {
        public async Task<TransactionCommandResult> Handle(TransactionCommand request, CancellationToken cancellationToken)
        {
            return new TransactionCommandResult()
            {
                ResponseCode = 00,
                Message = "Success",
                ApprovalCode = int.Parse(CommandHelper.GenerateApprovalCode()),
                DateTime = DateTime.Now
            };
        }
    }
}
