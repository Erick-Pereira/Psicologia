using AutoMapper;
using Entities;
using VisualLayer.Models.Cargo;

namespace VisualLayer.Profiles
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<CargoInsertViewModel, Cargo>();
        }
    }
}