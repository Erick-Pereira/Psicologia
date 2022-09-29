using AutoMapper;
using Entities;
using VisualLayer.Models;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Profiles
{
    public class SF36Profile : Profile
    {
        public SF36Profile()
        {
            CreateMap<FuncionarioRespostasQuestionarioSf36, FuncionarioRespostasQuestionarioSf36ViewModel>();
            CreateMap<FuncionarioRespostasQuestionarioSf36ViewModel, FuncionarioRespostasQuestionarioSf36>();

        }
    }
}