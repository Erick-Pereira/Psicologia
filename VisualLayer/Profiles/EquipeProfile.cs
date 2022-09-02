using AutoMapper;
using Entities;
using VisualLayer.Models.Equipe;

namespace VisualLayer.Profiles
{
    public class EquipeProfile : Profile
    {
        public EquipeProfile()
        {
            CreateMap<Equipe, EquipeSelectViewModel>();
        }
    }
}