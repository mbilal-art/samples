using Application.Commands.Account;
using Application.Queries.Account;
using AutoMapper;
using Domain.Aggregates;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.QueryHandlers.Account
{
    public class GetUserAccountByIdQueryHandler : IRequestHandler<GetUserAccountByIdQuery, GetUserAccountByIdQueryResult>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;
        public GetUserAccountByIdQueryHandler(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        public async Task<GetUserAccountByIdQueryResult> Handle(GetUserAccountByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _userAccountRepository.Get(Guid.Parse(query.Id));

            return new GetUserAccountByIdQueryResult()
            {
                IsSucceed = true
            };
        }
    }
}
