using Rh.Dominio;

namespace Rh.Negocio.Interfaces
{
   public interface ICidadeBo : IValidator<Cidade>
    {
        void Adicionar(Cidade cidade);
        void Apagar(int id);
        Cidade Mostrar(int id);
        void Editar(Cidade cidade);
        Cidade ObterPorId(int id);
    }
}
