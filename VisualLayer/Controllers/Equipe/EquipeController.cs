using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VisualLayer.Models.Equipe;
using VisualLayer.Security;

namespace VisualLayer.Controllers.Equipe
{
    public class EquipeController : CustomController
    {
        private readonly IEquipeService _EquipeService;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public EquipeController(IEquipeService equipeService, IFuncionarioService funcionarioService, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(funcionarioService, httpContextAccessor)
        {
            _EquipeService = equipeService;
            _funcionarioService = funcionarioService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Criar()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Criar(EquipeInsertViewModel equipeInsert)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Equipes()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }
    }
}