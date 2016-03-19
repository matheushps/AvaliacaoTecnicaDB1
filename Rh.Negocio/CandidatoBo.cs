using System;
using Rh.Dominio;
using Rh.Negocio.Interfaces;
using Rh.ORM;
using System.Data.Entity;

namespace Rh.Negocio
{
    public class CandidatoBo : ICandidatoBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Candidato candidato)
        {
            candidato.DataCadastro = DateTime.Now.ToLocalTime();
            db.Candidatos.Add(candidato);
            db.SaveChanges();
        }

        public void Apagar(int id)
        {
            Candidato candidato = db.Candidatos.Find(id);
            db.Candidatos.Remove(candidato);
            db.SaveChanges();
        }

        public void Editar(Candidato candidato)
        {
            db.Entry(candidato).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Candidato Mostrar(int id)
        {
            Candidato candidato = db.Candidatos.Find(id);
            return candidato;
        }

        public Candidato ObterPorId(int id)
        {
            Candidato candidato = db.Candidatos.Find(id);
            return candidato;
        }

        #region Validações

        public void ValidaAdicionar(Candidato domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Candidato domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Candidato domain)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
