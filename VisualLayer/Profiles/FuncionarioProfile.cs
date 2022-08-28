using AutoMapper;
using Entities;
using VisualLayer.Models;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<Cargo, FuncionarioInsertViewModel>();
            CreateMap<Funcionario, FuncionarioSelectViewModel>();
            CreateMap<Funcionario, FuncionarioUpdateViewModel>();
            CreateMap<FuncionarioInsertViewModel, Funcionario>();
            CreateMap<FuncionarioUpdateViewModel, Funcionario>();
            CreateMap<LoginModel, Funcionario>();
        }
    }
}