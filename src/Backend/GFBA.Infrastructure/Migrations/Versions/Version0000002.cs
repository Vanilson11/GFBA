using FluentMigrator;
using GFBA.Domain.Enums;

namespace GFBA.Infrastructure.Migrations.Versions;

[Migration(MigrationVersions.UPDATE_TABLE_USERS_ADD_COLUMN_PERMISSAO, "Adding column Permissao on table users")]
public class Version0000002 : ForwardOnlyMigration
{
    public override void Up()
    {
        Alter.Table("usuarios")
            .AddColumn("Permissao").AsString(100).NotNullable().WithDefaultValue(Roles.USER_MEMBER);
    }
}
