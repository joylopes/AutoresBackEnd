using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAutores.Data.Context;
using ProjetoAutores.Data.Repository;
using ProjetoAutores.Domain.Interfaces;

namespace ProjetoAutores.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddDbContext<MyContext>(
                option => option.UseSqlServer("Server=localhost;Database=DbProjetoAutores;Uid=sa;Pwd=acsj1996")
            );
        }
    }
}
