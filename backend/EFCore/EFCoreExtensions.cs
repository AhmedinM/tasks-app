using EFCore.Context;
using EFCore.Repositories.Lists;
using EFCore.Repositories.Tasks;
using EFCore.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore;
public static class EFCoreExtensions
{
    public static IServiceCollection AddEFCore(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder> dboptions,
        ServiceLifetime scope = ServiceLifetime.Scoped
    ) {
        services.AddDbContext<DataContext>(dboptions, scope);

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IListRepository, ListRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        
        return services;
    }
}
