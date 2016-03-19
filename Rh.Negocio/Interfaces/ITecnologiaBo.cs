using Rh.Dominio;

namespace Rh.Negocio.Interfaces
{
   public interface ITecnologiaBo : IValidator<Tecnologia>
    {
        void Adicionar(Tecnologia tecnologia);
        void Apagar(int id);
        Tecnologia Mostrar(int id);
        void Editar(Tecnologia tecnologia);
        Tecnologia ObterPorId(int id);
    }
}
