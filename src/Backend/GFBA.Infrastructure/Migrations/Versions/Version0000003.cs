using FluentMigrator;

namespace GFBA.Infrastructure.Migrations.Versions;

[Migration(MigrationVersions.CREATE_TABLE_FICHAS_BA, "Creating table fichasBA")]
public class Version0000003 : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("fichaBa")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Estudante").AsString(250).NotNullable()
            .WithColumn("Turma").AsInt16().NotNullable()
            .WithColumn("Turno").AsInt16().NotNullable()
            .WithColumn("DataNascimento").AsDateTime().NotNullable()
            .WithColumn("ContatoResponsavel").AsString(250).NotNullable()
            .WithColumn("Telefone").AsString(250).NotNullable()
            .WithColumn("DataAbertura").AsDateTime().NotNullable()
            .WithColumn("Motivo").AsInt16().NotNullable()
            .WithColumn("Status").AsInt16().NotNullable()
            .WithColumn("Observacoes").AsString(500).Nullable()
            .WithColumn("IdOrientador").AsGuid().ForeignKey();
    }
}
