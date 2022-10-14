using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Extensions;
using System.Security.Claims;

namespace VisualLayer.Security
{
    public class CustomController : Controller
    {
        private const string ENCRYPT = "ID";
        private readonly IFuncionarioService _FuncionarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomController(IFuncionarioService funcionarioService, IHttpContextAccessor httpContextAccessor)
        {
            _FuncionarioService = funcionarioService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult ThrowError(Exception ex)
        {
            return RedirectToAction(actionName: "Index", controllerName: "Erro", ResponseFactory<Response>.CreateFailureResponse(ex.Message));
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>

        public async Task<int> GetIdByCookie()

        {
            return Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT));
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>

        public async Task<Funcionario> GetFuncionarioByCookie()

        {
            return _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nivelPermissao"></param>
        /// <returns></returns>
        public async Task<IActionResult> Authorize(int nivelPermissao)
        {
            Funcionario verify = await GetFuncionarioByCookie();
            if (verify.Cargo.NivelPermissao != nivelPermissao || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            else
            {
                return null;
            }
        }
    }
}