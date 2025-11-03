using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;


namespace RiverBooks.Users;

public static class UsersModuleExtensions
{
    public static IServiceCollection AddUserModuleServices(
        this IServiceCollection services,
        ConfigurationManager config,
        ILogger logger)
    {
        var connectionString = config.GetConnectionString("UsersConnectionString");
        
        services.AddDbContext<UsersDbContext>(config => 
            config.UseSqlServer(connectionString));
        
        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<UsersDbContext>();
        
        logger.Information("{Module} module services registered", "Users");
        
        return services;
    }
}
