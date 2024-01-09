using Games.Repository;
using Microsoft.EntityFrameworkCore;

namespace Games.Data
{
    public static class DbExtensions
    {
        public static void InitializeDb(this IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();

            var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
            DbContext.Database.Migrate();

        }

        public static IServiceCollection AddRepositories(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connString = configuration.GetConnectionString("GameConnection");
            services.AddSqlServer<GameStoreContext>(connString)
                    .AddScoped<IGameRepository, EntityGameRepository>();

            return services;
        }
    }
}