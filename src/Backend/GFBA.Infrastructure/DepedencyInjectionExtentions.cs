using FluentMigrator.Runner;
using GFBA.Domain.Repositories;
using GFBA.Domain.Repositories.FichaBA;
using GFBA.Domain.Repositories.Usuarios;
using GFBA.Domain.Security.Cripitography;
using GFBA.Domain.Security.Tokens;
using GFBA.Domain.Services.LoggedUser;
using GFBA.Infrastructure.DataAccess;
using GFBA.Infrastructure.DataAccess.Repositories;
using GFBA.Infrastructure.DataAccess.Repositories.FichaBA;
using GFBA.Infrastructure.DataAccess.Repositories.Usuarios;
using GFBA.Infrastructure.Security.Criptography;
using GFBA.Infrastructure.Security.Tokens;
using GFBA.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GFBA.Infrastructure;
public static class DepedencyInjectionExtentions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddToken(services, configuration);
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddDatabaseMigration(services, configuration);

        services.AddScoped<IPasswordHasher, PasswordHashing>();
        services.AddScoped<ILoggedUser, LoggedUser>();
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signinKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(provider => new JwtTokenGenerator(expirationTimeMinutes, signinKey!));
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        var version = new Version(8, 0, 45);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<GFBADbContext>(config => config.UseMySql(connectionString, serverVersion));
    }

    private static void AddDatabaseMigration(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentMigratorCore().ConfigureRunner(config =>
        {
            config.AddMySql5()
            .WithGlobalConnectionString(_ =>
            {
                var connection = configuration.GetConnectionString("Connection");

                return connection!;
            })
            .ScanIn(Assembly.Load("GFBA.Infrastructure"))
            .For.All();
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOffWork, UnitOffWork>();
        services.AddScoped<IWriteOnlyUsuariosRepository, UsuariosRepository>();
        services.AddScoped<IReadOnlyUsuariosRepository, UsuariosRepository>();
        services.AddScoped<IWriteOnlyFichaBaRepository, FichaBaRepository>();
    }
}
