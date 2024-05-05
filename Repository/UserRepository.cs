using Contracts;
using Entities.Models;

namespace Repository;

public class UserRepository: RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}