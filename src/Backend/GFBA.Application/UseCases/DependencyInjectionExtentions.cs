using GFBA.Application.UseCases.FichasBA.Registrar;
using GFBA.Application.UseCases.Usuarios.Registrar;
using Microsoft.Extensions.DependencyInjection;

namespace GFBA.Application.UseCases;
public static class DependencyInjectionExtentions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegistrarFichaBAUseCase, RegistrarFichaBAUseCase>();
        services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
    }
}
