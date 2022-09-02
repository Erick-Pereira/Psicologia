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
            CreateMap<FuncionarioSelectViewModel, Funcionario>();
            CreateMap<Funcionario, FuncionarioUpdateViewModel>();
            CreateMap<FuncionarioInsertViewModel, Funcionario>();
            CreateMap<FuncionarioUpdateViewModel, Funcionario>();
            CreateMap<LoginModel, Funcionario>();
            CreateMap<Funcionario, LoginModel>();
            CreateMap<Funcionario, FuncionarioUpdateAdmViewModel>();
            CreateMap<FuncionarioUpdateAdmViewModel, Funcionario>();
            CreateMap<Funcionario, FuncionarioDetailViewModel>();
            CreateMap<FuncionarioDetailViewModel, Funcionario>();
        }
    }
}