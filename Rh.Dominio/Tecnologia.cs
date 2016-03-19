using System.ComponentModel.DataAnnotations;

namespace Rh.Dominio
{
    /// <summary>
    /// Classe no qual serão cadastradas as tecnologias.
    /// </summary>
    public class Tecnologia
    {
        public int TecnologiaId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Pontos")]
        public decimal Peso { get; set; }
    }
}