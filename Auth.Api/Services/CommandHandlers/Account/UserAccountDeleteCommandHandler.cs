using Application.Commands.Account;
using AutoMapper;
using Domain.Aggregates;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommandHandlers.Account
{
    public class UserAccountDeleteCommandHandler : IRequestHandler<UserAccountDeleteCommand, UserAccountDeleteCommandResult>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;
        public UserAccountDeleteCommandHandler(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }
        public async Task<UserAccountDeleteCommandResult> Handle(UserAccountDeleteCommand command, CancellationToken cancellationToken)
        {
            await _userAccountRepository.Remove(Guid.Parse(command.Id));
            return new UserAccountDeleteCommandResult()
            {
                IsSucceed = true
            };
        }
    }
}
