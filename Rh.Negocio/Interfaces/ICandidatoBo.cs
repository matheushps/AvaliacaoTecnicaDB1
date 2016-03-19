using Rh.Dominio;

namespace Rh.Negocio.Interfaces
{
   public interface ICandidatoBo : IValidator<Candidato>
    {
        void Adicionar(Candidato candidato);
        void Apagar(int id);
        Candidato Mostrar(int id);
        void Editar(Candidato candidato);
        Candidato ObterPorId(int id);
    }
}
