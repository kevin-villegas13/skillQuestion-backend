using SkillQuest_backend.Data;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

namespace SkillQuest_backend.DependencyInjection;

public static class DatabaseServiceCollectionExtensions
{
    public static void AddDatabaseServices(this IServiceCollection services, string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("La cadena de conexión 'DATABASE_URL' no está configurada.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
}

