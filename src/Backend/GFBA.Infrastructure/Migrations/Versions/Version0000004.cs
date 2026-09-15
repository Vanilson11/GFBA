using FluentMigrator;

namespace GFBA.Infrastructure.Migrations.Versions;

[Migration(MigrationVersions.CREATE_TABLE_ACAO_BA, "Creating table acaoBA")]
public class Version0000004 : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("acaoba")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Tipo").AsInt16().NotNullable()
            .WithColumn("Data").AsDateTime().NotNullable()
            .WithColumn("Observacao").AsString(500).Nullable()
            .WithColumn("IdFichaBA").AsGuid().Nullable().ForeignKey();
    }
}
