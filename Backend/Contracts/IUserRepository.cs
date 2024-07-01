

using Entities.Models;

namespace Contracts;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync(bool trackChanges);
    Task<string?> GetUserIdByName(string? username, bool trackChanges);
    

    Task<User?> GetUserByIdAsync(string? id, bool trackChanges);
}