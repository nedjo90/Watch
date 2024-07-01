using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<User>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
    

    public async Task<string?> GetUserIdByName(string? username, bool trackChanges)
    {
        User? user = await FindByCondition(e => e.UserName != null && e.UserName.Equals(username), trackChanges)
            .FirstOrDefaultAsync();
        return user?.Id;
    }

    public async Task<User?> GetUserByIdAsync(string? id, bool trackChanges)
    {
        return await FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    }
}