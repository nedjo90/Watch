using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{



    public ServiceManager
        (IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
    }
}