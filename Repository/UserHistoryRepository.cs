using Contracts;
using Entities.Models;

namespace Repository;

public class UserHistoryRepository : RepositoryBase<UserHistory>, IUserHistoryRepository
{
    public UserHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}