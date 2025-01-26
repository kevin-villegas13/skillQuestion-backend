using SkillQuest_backend.Data;
using DotNetEnv;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace SkillQuest_backend.DependencyInjection;

public static class DatabaseServiceCollectionExtensions
{
    public static void AddDatabaseServices(this IServiceCollection services)
    {
        Env.Load();

        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("La cadena de conexión 'DATABASE_URL' no está configurada.");

        // Configurar el DbContext con PostgreSQL
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}

