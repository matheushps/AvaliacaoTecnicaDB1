using System;
using System.ComponentModel.DataAnnotations;

namespace Rh.Dominio
{
    /// <summary>
    /// Classe no qual será cadastrada a formação do candidato
    /// </summary>
   public class Formacao
    {
        public int FormacaoId { get; set; }
        public string Curso { get; set; }
        [Display(Name = "Instituição")]
        public string Instituicao { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Data de Conclusão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Conclusao { get; set; }
        [Display(Name = "Código do Candidato")]
        public int CadidatoId { get; set; }
        public virtual Candidato Candidato { get; set; }
    }
}
