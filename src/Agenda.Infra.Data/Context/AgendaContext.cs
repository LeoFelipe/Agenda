using Agenda.Domain.Entities;
using Agenda.Infra.Data.EntitiesMapping;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Agenda.Infra.Data.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext() : base("Agenda")
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()                
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.AddFromAssembly(typeof(ClienteMap).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("DataEdicao").CurrentValue = entry.Property("DataCadastro").CurrentValue;

                    if (entry.Entity.GetType().GetProperty("Ativo") != null)
                        entry.Property("Ativo").CurrentValue = true;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataEdicao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
