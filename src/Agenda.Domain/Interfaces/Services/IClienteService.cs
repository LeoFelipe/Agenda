using Agenda.Domain.Entities;
using System.Collections.Generic;

namespace Agenda.Domain.Interfaces.Services
{
    public interface IClienteService : IService<Cliente>
    {
        IEnumerable<Cliente> ObterAtivos();
        IEnumerable<Cliente> ObterPorNome(string nome);
        IEnumerable<Cliente> ObterPorEmail(string email);
    }
}