using Domain.Aggregates;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly DbContext _dbContext;
        public UserAccountRepository(DbContext context)
        {
            _dbContext = context;
        }

        public async Task<User> Add(User user)
        {
            return await Task.FromResult<User>(new User());
        }

        public async Task<User> Update(User user)
        {
            return await Task.FromResult<User>(new User());
        }

        public async Task<User> Remove(Guid userId)
        {
            return await Task.FromResult<User>(new User());
        }

        public async Task<User> Get(Guid userId)
        {
            return await Task.FromResult<User>(new User());
        }

        public async Task<List<User>> Get()
        {
            return await Task.FromResult<List<User>>(new List<User>());
        }
    }
}
