using Agenda.Domain.Entities;
using System.Collections.Generic;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Domain.Interfaces.Services;
using Agenda.Domain.Core.Notifications;

namespace Agenda.Domain.Services
{
    public class ClienteService : Service<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository, IDomainNotificationHandler dnh)
            : base(clienteRepository, dnh)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            return _clienteRepository.ObterAtivos();
        }

        public IEnumerable<Cliente> ObterPorNome(string nome)
        {
            return _clienteRepository.ObterPorNome(nome);
        }

        public IEnumerable<Cliente> ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }
    }
}
