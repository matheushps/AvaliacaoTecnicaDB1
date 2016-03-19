using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rh.Dominio
{
    /// <summary>
    /// Classe no qual será inserido os dados dos candidatos
    /// </summary>
  public class Candidato
    {
        public int CandidatoId { get; set; }
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }
        public string Email { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public List<Tecnologia> Tecnologias;
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

    }
}
