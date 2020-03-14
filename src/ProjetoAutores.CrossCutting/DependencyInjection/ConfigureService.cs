using Microsoft.Extensions.DependencyInjection;
using ProjetoAutores.Domain.Interfaces.Services.Autor;
using ProjetoAutores.Service.Services;

namespace ProjetoAutores.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAutorService, AutorService>();
        }
    }
}
