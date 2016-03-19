using Rh.Dominio;

namespace Rh.Negocio.Interfaces
{
   public interface IEntrevistaBo : IValidator<Entrevista>
    {
        void Adicionar(Entrevista entrevista);
        void Apagar(int id);
        Entrevista Mostrar(int id);
        void Editar(Entrevista entrevista);
        Entrevista ObterPorId(int id);
    }
}
