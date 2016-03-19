using System.ComponentModel.DataAnnotations;

namespace Rh.Dominio
{
    /// <summary>
    /// Classe no qual serão inseridos os estados
    /// </summary>
    public class Estado
    {
        public int EstadoId { get; set; }
        [Display(Name = "Estado")]
        public string Nome { get; set; }
    }
}