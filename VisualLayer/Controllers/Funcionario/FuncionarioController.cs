using AutoMapper;
using BusinessLogicalLayer;
using Microsoft.AspNetCore.Mvc;
using Shared;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Controllers.Funcionario
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            FuncionarioService funcionarioService = new FuncionarioService();
            DataResponse<Entities.Funcionario> dataResponse = funcionarioService.GetAll();
            MapperConfiguration mapper = new MapperConfiguration(m =>
             m.CreateMap<Entities.Funcionario, FuncionarioSelectViewModel>()
         );

            List<FuncionarioSelectViewModel> Funcionarios =
                mapper.CreateMapper().Map<List<FuncionarioSelectViewModel>>(dataResponse.Data);
            return View(Funcionarios);
        }
    }
}