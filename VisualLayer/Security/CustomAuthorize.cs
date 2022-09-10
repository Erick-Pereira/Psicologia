using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Extensions;
using System.Security.Claims;

namespace VisualLayer.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IFuncionarioService _FuncionarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomAuthorizeAttribute(IFuncionarioService funcionarioService, IHttpContextAccessor httpContextAccessor)
        {
            _FuncionarioService = funcionarioService;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            int nivelPermissao = (int)context.HttpContext.Items["nivelPermissao"];
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt("ID"))).Result.Item;
            if (verify.Cargo.NivelPermissao != nivelPermissao || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                context.HttpContext.Response.Redirect("/Home/Index");
            }
        }
    }
}