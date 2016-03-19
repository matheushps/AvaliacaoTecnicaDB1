using System;
using System.ComponentModel.DataAnnotations;

namespace Rh.Dominio
{
    /// <summary>
    /// Classe no qual será cadastrado os dados da entrevista.
    /// </summary>
    public class Entrevista
    {
        public int EntrevistaId { get; set; }
        [Display(Name = "Pontos da Entrevista")]
        public decimal Nota { get; set; }
        [Display(Name = "Comentário")]
        public string Comentario { get; set; }
        [Display(Name = "Data da Entrevista")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataEntrevista { get; set; }
        [Display(Name = "Vaga")]
        public int VagaId { get; set; }
        public virtual Vaga Vaga { get; set; }
        [Display(Name = "Candidato")]
        public int CandidatoId { get; set; }
        public virtual Candidato Candidato { get; set; }
    }
}
