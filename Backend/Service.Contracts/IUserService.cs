

namespace Service.Contracts;

public interface IUserService
{
    Task<string> GetUserIdByUserName(string userName, bool trackChanges);
    Task<string> GetUserIdByUserName();

    Task<bool> CheckIfUserIdIsExisting(string? id);
    Task<bool> CheckIfUserIdIsExisting(Guid? id);
}