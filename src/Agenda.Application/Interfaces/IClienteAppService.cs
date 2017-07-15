using Agenda.Application.ViewModels.Cliente;
using System.Collections.Generic;

namespace Agenda.Application.Interfaces
{
    public interface IClienteAppService : IAppService<ClienteViewModel>
    {
        IEnumerable<ClienteViewModel> ObterAtivos();
        IEnumerable<ClienteViewModel> ObterPorNome(string nome);
        IEnumerable<ClienteViewModel> ObterPorEmail(string email);
    }
}
