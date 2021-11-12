using AutoMapper;
using Core;
using RecolhakiWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecolhakiWeb.Mappers
{
    public class NotificarProblemaProfile : Profile
    {
        public NotificarProblemaProfile()
        {
            CreateMap<NotificarProblemaViewModel, Notificacao>().ReverseMap();
        }
    }
}
