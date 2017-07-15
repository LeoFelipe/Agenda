using Agenda.Domain.Entities;
using System.Linq;

namespace Agenda.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IQueryable<Cliente> ObterAtivos();
        IQueryable<Cliente> ObterPorNome(string nome);
        IQueryable<Cliente> ObterPorEmail(string email);
    }
}
