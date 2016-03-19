using Rh.Dominio;

namespace Rh.Negocio.Interfaces
{
    public interface IFormacaoBo : IValidator<Formacao>
    {
        void Adicionar(Formacao formacao);
        void Apagar(int id);
        Formacao Mostrar(int id);
        void Editar(Formacao formacao);
        Formacao ObterPorId(int id);
    }
}
