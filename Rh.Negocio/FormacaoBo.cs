using System;
using Rh.Dominio;
using Rh.Negocio.Interfaces;
using Rh.ORM;
using System.Data.Entity;

namespace Rh.Negocio
{
    public class FormacaoBo : IFormacaoBo
    {
        private Contexto db = new Contexto();
        public void Adicionar(Formacao formacao)
        {
            db.Formacoes.Add(formacao);
            db.SaveChanges();
        }

        public void Apagar(int id)
        {
            Formacao formacao = db.Formacoes.Find(id);
            db.Formacoes.Remove(formacao);
            db.SaveChanges();
        }

        public void Editar(Formacao formacao)
        {
            db.Entry(formacao).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Formacao Mostrar(int id)
        {
            Formacao formacao = db.Formacoes.Find(id);
            return formacao;
        }

        public Formacao ObterPorId(int id)
        {
            Formacao formacao = db.Formacoes.Find(id);
            return formacao;
        }

        #region Validações
        public void ValidaAdicionar(Formacao domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Formacao domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Formacao domain)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
