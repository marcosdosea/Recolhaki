using AutoMapper;
using Core;
using RecolhakiWeb.ViewModels;

namespace RecolhakiWeb.Mappers
{
    public class ColetorProfile : Profile
    {
        public ColetorProfile()
        {
            CreateMap<ColetorViewModel, Pessoa>().ReverseMap();
        }
    }
}
