using Rh.Dominio;

namespace Rh.Negocio.Interfaces
{
   public interface IEstadoBo : IValidator<Estado>
    {
        void Adicionar(Estado estado);
        void Apagar(int id);
        Estado Mostrar(int id);
        void Editar(Estado estado);
        Estado ObterPorId(int id);
    }
}
