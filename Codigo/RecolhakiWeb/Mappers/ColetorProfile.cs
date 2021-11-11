using AutoMapper;
using Core;
using RecolhakiWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
