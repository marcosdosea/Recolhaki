

using AutoMapper;
using Core;
using RecolhakiWeb.ViewModels;

namespace RecolhakiWeb.Mappers
{
    public class DisponibilizarMaterialProfile : Profile
    {
        public DisponibilizarMaterialProfile()
        {
            CreateMap<DisponibilizarMaterialViewModel, Doacaomaterialreciclavel>().ReverseMap();
        }
    }
}
