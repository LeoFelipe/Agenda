using Agenda.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Agenda.Infra.Data.EntitiesMapping
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("enderecos");

            Ignore(x => x.ValidationResult);
            Ignore(x => x.CascadeMode);
            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.DataEdicao).IsRequired();

            HasKey(x => x.EnderecoId);
            Property(x => x.Logradouro).HasMaxLength(150).IsRequired();
            Property(x => x.Numero).HasMaxLength(20).IsRequired();
            Property(x => x.Complemento).HasMaxLength(150);
            Property(x => x.Bairro).HasMaxLength(50).IsRequired();
            Property(x => x.Cep).HasMaxLength(8).IsFixedLength().IsRequired();
            Property(x => x.Cidade).HasMaxLength(50).IsRequired();
            Property(x => x.Estado).HasMaxLength(50).IsRequired();

            HasRequired(x => x.Cliente)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(x => x.ClienteId);
        }
    }
}
