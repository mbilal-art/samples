using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public interface IUserAccountRepository
    {
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<User> Remove(Guid userId);
        Task<User> Get(Guid userId);
        Task<List<User>> Get();
    }
}
