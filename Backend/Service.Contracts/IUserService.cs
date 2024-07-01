

using Entities.Models;

namespace Service.Contracts;

public interface IUserService
{
    Task<string> GetUserIdByUserName(string userName, bool trackChanges);
    Task<IList<string>> GetCurrentUserRoles();
    Task<string> GetUserIdByUserName();
    Task<User?> GetCurrentUser();
    Task<bool> CheckIfUserIdIsExisting(string? id);
    Task<bool> CheckIfUserIdIsExisting(Guid? id);
}