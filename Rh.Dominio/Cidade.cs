using System.ComponentModel.DataAnnotations;

namespace Rh.Dominio
{
    /// <summary>
    /// Classe no qual serão cadastradas as cidades
    /// </summary>
    public class Cidade
    {
        public int CidadeId { get; set; }
        [Display(Name = "Cidade")]
        public string Nome { get; set; }
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }

    }
}