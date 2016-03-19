using Rh.Dominio;

namespace Rh.Negocio.Interfaces
{
   public interface IVagaBo : IValidator<Vaga>
    {
        void Adicionar(Vaga vaga);
        void Apagar(int id);
        Vaga Mostrar(int id);
        void Editar(Vaga vaga);
        Vaga ObterPorId(int id);
    }
}
