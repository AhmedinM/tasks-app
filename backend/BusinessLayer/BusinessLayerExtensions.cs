using AutoMapper;
using BusinessLayer.Mappings;
using BusinessLayer.Services.Accounts;
using BusinessLayer.Services.Lists;
using BusinessLayer.Services.Tasks;
using BusinessLayer.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer;
public static class BusinessLayerExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services) {
        var profileList = new List<Profile>();

        profileList.Add(new MappingUsers());
        profileList.Add(new MappingLists());
        profileList.Add(new MappingTasks());

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IListService, ListService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddAutoMapper(c => c.AddProfiles(profileList), typeof(List<Profile>));

        return services;
    }
}
