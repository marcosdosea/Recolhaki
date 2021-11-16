using AutoMapper;
using Core;

namespace RecolhakiWeb.Mappers
{
    public class AvaliacaoProfile : Profile
    {
        public AvaliacaoProfile()
        {
            CreateMap<AvaliacaoProfile, Avaliacao>().ReverseMap();
        }
    }
}
