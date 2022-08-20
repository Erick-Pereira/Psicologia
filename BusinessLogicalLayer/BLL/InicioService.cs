using BusinessLogicalLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class InicioService : IInicioService
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IEnderecoService _enderecoService;

        public InicioService(IFuncionarioService funcionarioService, IEnderecoService enderecoService)
        {
            _funcionarioService = funcionarioService;
            _enderecoService = enderecoService;
        }

        public async Task<Response> Iniciar()
        {
            if (!_funcionarioService.Iniciar().Result.Item)
            {
                if (!_enderecoService.Iniciar().Result.Item)
                {
                    _enderecoService.Insert(new Endereco() { Bairro = new Bairro() { Cidade = new Cidade() { Estado = new Estado() } } });
                }
            }
            return new Response();
        }
    }
}