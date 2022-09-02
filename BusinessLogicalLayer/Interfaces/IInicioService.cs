using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IInicioService
    {
        Task<Response> Iniciar();
    }
}