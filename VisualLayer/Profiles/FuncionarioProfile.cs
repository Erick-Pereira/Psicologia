﻿using AutoMapper;
using Entities;
using VisualLayer.Models;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<FuncionarioInsertViewModel, Funcionario>();
            CreateMap<Funcionario, FuncionarioSelectViewModel>();
            CreateMap<LoginModel, Funcionario>();
        }
    }
}