using AutoMapper;
using Core;
using RecolhakiWeb.ViewModels;

namespace RecolhakiWeb.Mappers
{
    public class MaterialreciclavelProfile : Profile
    {
        public MaterialreciclavelProfile()
        {
            CreateMap<MaterialreciclavelViewModel, Materialreciclavel>().ReverseMap();
        }
    }
}
