using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Account
{
    public class GetUserAccountByIdQuery : IRequest<GetUserAccountByIdQueryResult>
    {
        public string Id { get; set; }
    }
}
