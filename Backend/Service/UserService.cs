using System.Reflection;
using System.Security.Claims;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransfertObject.User;

namespace Service;

internal class UserService : ServiceBase, IUserService
{
    public UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor,
        IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(userManager, httpContextAccessor, serviceManager,
        repositoryManager, loggerManager, mapper)
    {
    }

    public async Task<IList<string>> GetCurrentUserRoles()
    {
        User? user = UserManager.FindByNameAsync(HttpContextAccessor.HttpContext.User.Identity?.Name ?? string.Empty)
            .Result;
        if (user is null)
            throw new NotConnectedException();
        IList<string> roles = await UserManager.GetRolesAsync(user);
        return roles;
    }

    public User? GetCurrentUser()
    {
        User? user = UserManager.FindByNameAsync(HttpContextAccessor.HttpContext.User.Identity?.Name ?? string.Empty)
            .Result;
        if (user is null)
            throw new NotConnectedException();
        Console.WriteLine("USER =====> {0}", user?.Id);
        return user;
    }


    public async Task<UserInfoDto> GetCurrentUserInfo()
    {
        User? user = GetCurrentUser();
        if (user is null)
            throw new NotConnectedException();
        DisplayClassInfo(user);
        UserInfoDto userInfoDto = Mapper.Map<UserInfoDto>(user);
        userInfoDto.ProfessionalStatus =
            (await RepositoryManager.ProfessionalStatusRepository.GetById(user!.ProfessionalStatusId, false))!.Label;
        userInfoDto.Roles = await GetCurrentUserRoles();
        userInfoDto.Username = user.UserName;
        return userInfoDto;
        // IEnumerable<Document> userDocument =
        //     await RepositoryManager.DocumentRepository.GetUserDocumentsAsync(user.Id, false);
        // int count = 0;
        // foreach (var document in userDocument)
        // {
        //     Console.Write(count);
        //     DisplayClassInfo(document);
        //     Console.WriteLine("document type label: {0}", document.DocumentType?.Label);
        //     Console.WriteLine("document status label: {0}", document.DocumentStatus?.Label);
        //     count++;
        // }
        //
        // IEnumerable<LateMiss> userLateMisses = await RepositoryManager.LateMissRepository.GetUserLateMissesAsync(user.Id, false);
        // Console.WriteLine("lateMisses:");
        // count = 0;
        // foreach (var lateMiss in userLateMisses)
        // {
        //     Console.Write(count);
        //     DisplayClassInfo(lateMiss);
        //     Console.WriteLine("lateMiss type: {0}", lateMiss.LateMissType.Label);
        //     Console.WriteLine("lateMiss status: {0}", lateMiss.LateMissStatus.Label);
        //     foreach (var lateMissDocument in lateMiss.LateMissDocuments)
        //     {
        //         DisplayClassInfo(lateMissDocument);
        //     }
        //     count++;
        // }
    }

    private void DisplayClassInfo(object? obj)
    {
        if (obj is null)
        {
            Console.WriteLine("{0} = NULL", nameof(obj));
            return;
        }

        Type type = obj.GetType();

        PropertyInfo[] properties = type.GetProperties();

        Console.WriteLine($"Type: {type.Name}");
        Console.WriteLine("Properties:");

        foreach (PropertyInfo property in properties)
        {
            object? value = property.GetValue(obj, null);
            Console.WriteLine($" - {property.Name}: {value}");
        }
    }

    public async Task<string> GetUserIdByUserName(string? userName, bool trackChanges)
    {
        string? userId = await RepositoryManager.UserRepository.GetUserIdByName(userName, false);
        if (userId is null)
            throw new UserIdNotFoundBadRequest();
        return userId;
    }

    public async Task<string> GetUserIdByUserName()
    {
        return await GetUserIdByUserName(HttpContextAccessor.HttpContext.User.Identity?.Name, false);
    }

    public Task<bool> CheckIfUserIdIsExisting(Guid? id)
    {
        return CheckIfUserIdIsExisting(id.ToString());
    }

    public async Task<bool> CheckIfUserIdIsExisting(string? id)
    {
        User? user =
            await RepositoryManager.UserRepository.GetUserByIdAsync(id, false);
        return user != null;
    }
}