using System.Data.Entity.Migrations;
using Agenda.Infra.Data.Context;

namespace Agenda.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AgendaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AgendaContext context)
        {

        }
    }
}
