using FluentMigrator;

namespace GFBA.Infrastructure.Migrations.Versions;

[Migration(MigrationVersions.TABLE_USERS, "Creating table users")]
public class Version0000001 : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("usuarios")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Nome").AsString(250).NotNullable()
            .WithColumn("Matricula").AsString(11).NotNullable()
            .WithColumn("Cargo").AsInt16().NotNullable()
            .WithColumn("Email").AsString(250).NotNullable()
            .WithColumn("Senha").AsString(2000).NotNullable()
            .WithColumn("Ativo").AsBoolean().WithDefaultValue(true);
    }
}
