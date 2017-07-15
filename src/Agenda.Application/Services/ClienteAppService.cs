using System.Collections.Generic;
using Agenda.Application.Interfaces;
using Agenda.Application.ViewModels.Cliente;
using Agenda.Domain.Interfaces.Services;
using AutoMapper;
using Agenda.Infra.Data.UoW;
using Agenda.Domain.Entities;

namespace Agenda.Application.Services
{
    public class ClienteAppService : AppService, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnityOfWork uow)
            : base(uow)
        {
            _clienteService = clienteService;
        }

        public void Remover(int id)
        {
            _clienteService.Delete(id);
            _uow.Commit();
        }

        public ClienteViewModel Adicionar(ClienteViewModel vm)
        {
            var cliente = Mapper.Map<Cliente>(vm);
            cliente.Enderecos.Add(Mapper.Map<Endereco>(vm.Endereco));

            _clienteService.Insert(cliente);

            _uow.Commit();
            return vm;
        }

        public ClienteViewModel Atualizar(ClienteViewModel vm)
        {
            var entity = Mapper.Map<Cliente>(vm);

            _clienteService.Update(entity);

            _uow.Commit();
            return vm;
        }

        public ClienteViewModel ObterPorId(int id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.GetById(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.GetAll());
        }

        public void Dispose()
        {
            _clienteService.Dispose();
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterAtivos());
        }

        public IEnumerable<ClienteViewModel> ObterPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterPorNome(nome));
        }

        public IEnumerable<ClienteViewModel> ObterPorEmail(string email)
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterPorEmail(email));
        }
    }
}
