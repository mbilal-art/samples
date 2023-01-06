using Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CommandHandlers
{
    public class InboundSmsReplyCommandHandler : IRequestHandler<InboundSmsReplyCommand, InboundSmsReplyCommandResult>
    {
        public async Task<InboundSmsReplyCommandResult> Handle(InboundSmsReplyCommand command, CancellationToken cancellationToken)
        {
            //here to add additional logic for db add against unique identifier i.e. command.SmsSid

            return new InboundSmsReplyCommandResult()
            {
                IsSucceed = true
            };
        }
    }
}
