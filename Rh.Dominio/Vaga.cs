using System;
using System.ComponentModel.DataAnnotations;

namespace Rh.Dominio
{
    /// <summary>
    /// Classe no qual será cadastrado as vagas
    /// </summary>
   public class Vaga
    {
        public int VagaId { get; set; }
        [Display(Name = "Função")]
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Situação")]
        public bool Situacao { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

    }
}
