using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace GFBA.Infrastructure;
public class DatabaseMigration
{
    public static void MigrateDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        runner.ListMigrations();
        runner.MigrateUp();
    }
}
