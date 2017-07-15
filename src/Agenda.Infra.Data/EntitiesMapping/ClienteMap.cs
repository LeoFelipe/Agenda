using Agenda.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Agenda.Infra.Data.EntitiesMapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("clientes");

            Ignore(x => x.ValidationResult);
            Ignore(x => x.CascadeMode);
            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.DataEdicao).IsRequired();

            HasKey(x => x.ClienteId);
            Property(x => x.ClienteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasMaxLength(80).IsRequired();
            Property(x => x.DataNascimento);
            Property(x => x.Email).HasMaxLength(50);
            Property(x => x.CelularPrincipal).HasMaxLength(15);
            Property(x => x.CelularSecundario).HasMaxLength(15);
            Property(x => x.Telefone).HasMaxLength(15);
            Property(x => x.Empresa).HasMaxLength(50);
            Property(x => x.Ativo).IsRequired();

            HasMany(x => x.Enderecos)
                .WithRequired(x => x.Cliente)
                .HasForeignKey(x => x.ClienteId);
        }
    }
}
