using AutoMapper;
using Agenda.Application.ViewModels.Cliente;
using Agenda.Domain.Entities;
using Agenda.Application.ViewModels.Endereco;

namespace Agenda.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}
