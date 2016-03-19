using System;
using Rh.Dominio;
using Rh.Negocio.Interfaces;
using Rh.ORM;
using System.Data.Entity;

namespace Rh.Negocio
{
    public class EstadoBo : IEstadoBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Estado estado)
        {
            db.Estados.Add(estado);
            db.SaveChanges();
        }

        public void Apagar(int id)
        {
            Estado estado = db.Estados.Find(id);
            db.Estados.Remove(estado);
            db.SaveChanges();
        }

        public void Editar(Estado estado)
        {
            db.Entry(estado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Estado Mostrar(int id)
        {
            Estado estado = db.Estados.Find(id);
            return estado;
        }

        public Estado ObterPorId(int id)
        {
            Estado estado = db.Estados.Find(id);
            return estado;
        }

        #region Validações
        public void ValidaAdicionar(Estado domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Estado domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Estado domain)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
