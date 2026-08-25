using GFBA.Domain.Security.Cripitography;
using GFBA.Domain.Security.Tokens;
using GFBA.Infrastructure.Security.Criptography;
using GFBA.Infrastructure.Security.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GFBA.Infrastructure;
public static class DepedencyInjectionExtentions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddToken(services, configuration);

        services.AddScoped<IPasswordHasher, PasswordHashing>();
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signinKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(provider => new JwtTokenGenerator(expirationTimeMinutes, signinKey!));
    }
}
