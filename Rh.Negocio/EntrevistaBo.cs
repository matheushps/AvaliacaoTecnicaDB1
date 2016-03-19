using System;
using Rh.Dominio;
using Rh.Negocio.Interfaces;
using Rh.ORM;
using System.Data.Entity;

namespace Rh.Negocio
{
    public class EntrevistaBo : IEntrevistaBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Entrevista entrevista)
        {
            db.Entrevistas.Add(entrevista);
            db.SaveChanges();
        }

        public void Apagar(int id)
        {
            Entrevista entrevista = db.Entrevistas.Find(id);
            db.Entrevistas.Remove(entrevista);
            db.SaveChanges();
        }

        public void Editar(Entrevista entrevista)
        {
            db.Entry(entrevista).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Entrevista Mostrar(int id)
        {
            Entrevista entrevista = db.Entrevistas.Find(id);
            return entrevista;
        }

        public Entrevista ObterPorId(int id)
        {
            Entrevista entrevista = db.Entrevistas.Find(id);
            return entrevista;
        }

        #region Validações
        public void ValidaAdicionar(Entrevista domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Entrevista domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Entrevista domain)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
