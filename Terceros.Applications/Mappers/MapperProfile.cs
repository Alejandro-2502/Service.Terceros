using AutoMapper;
using Terceros.Applications.DTOs.People;
using Terceros.Applications.Responses.People;

namespace Terceros.Applications.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PeopleDTO, PeopleResponse>();
            CreateMap<ResultDTO, ResultResponse>();
        }
    }
}
