using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    internal interface IInicioService
    {
        Task<Response> Iniciar();
    }
}