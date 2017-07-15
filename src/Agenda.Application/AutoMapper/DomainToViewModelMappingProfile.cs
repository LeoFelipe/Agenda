using AutoMapper;
using Agenda.Application.ViewModels.Cliente;
using Agenda.Domain.Entities;
using Agenda.Application.ViewModels.Endereco;

namespace Agenda.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
        }
    }
}
