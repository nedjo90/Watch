

using Entities.Models;
using Shared.DataTransfertObject.User;

namespace Service.Contracts;

public interface IUserService
{
    Task<UserInfoDto> GetCurrentUserInfo(); 
    Task<string> GetUserIdByUserName(string userName, bool trackChanges);
    Task<IList<string>> GetCurrentUserRoles();
    Task<string> GetUserIdByUserName();
    User? GetCurrentUser();
    Task<bool> CheckIfUserIdIsExisting(string? id);
    Task<bool> CheckIfUserIdIsExisting(Guid? id);
}