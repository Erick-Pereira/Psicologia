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
            CreateMap<Funcionario, FuncionarioDetailViewModel>();
            CreateMap<Funcionario, FuncionarioSelectViewModel>();
            CreateMap<Funcionario, FuncionarioUpdateAdmViewModel>();
            CreateMap<Funcionario, FuncionarioUpdateViewModel>();
            CreateMap<Funcionario, LoginModel>();
            CreateMap<FuncionarioDetailViewModel, Funcionario>();
            CreateMap<FuncionarioInsertViewModel, Funcionario>();
            CreateMap<FuncionarioSelectViewModel, Funcionario>();
            CreateMap<FuncionarioUpdateAdmViewModel, Funcionario>();
            CreateMap<FuncionarioUpdateViewModel, Funcionario>();
            CreateMap<LoginModel, Funcionario>();
        }
    }
}