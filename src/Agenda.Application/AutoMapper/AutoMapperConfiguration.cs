using AutoMapper;

namespace Agenda.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(ps => {
                ps.AddProfile<DomainToViewModelMappingProfile>();
                ps.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
