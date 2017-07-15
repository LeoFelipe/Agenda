using Agenda.Domain.Core.Helpers;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infra.Data.Context;
using System.Linq;

namespace Agenda.Infra.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AgendaContext context) : base(context)
        {

        }

        public IQueryable<Cliente> ObterAtivos()
        {
            var order = new SortHelper("Email", TypeOrder.ASC);
            order.AddThenBy("Nome", TypeThen.DESC);
            order.AddThenBy("DataNascimento", TypeThen.DESC);

            return GetBy(x => x.Ativo);
        }

        public IQueryable<Cliente> ObterPorEmail(string email)
        {
            return GetBy(x => x.Email.ToUpper().Contains(email.ToUpper()));
        }

        public IQueryable<Cliente> ObterPorNome(string nome)
        {
            return GetBy(x => x.Nome.ToUpper().Contains(nome.ToUpper()));
        }

        public override void Delete(int id)
        {
            var cliente = GetById(id);
            cliente.Ativo = false;
            Update(cliente);
        }
    }
}
