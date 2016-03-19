using System;
using Rh.Dominio;
using Rh.Negocio.Interfaces;
using Rh.ORM;
using System.Data.Entity;

namespace Rh.Negocio
{
    public class CidadeBo : ICidadeBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Cidade cidade)
        {
            db.Cidades.Add(cidade);
            db.SaveChanges();
        }

        public void Apagar(int id)
        {
            Cidade cidade = db.Cidades.Find(id);
            db.Cidades.Remove(cidade);
            db.SaveChanges();
        }

        public void Editar(Cidade cidade)
        {
            db.Entry(cidade).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Cidade Mostrar(int id)
        {
            Cidade cidade = db.Cidades.Find(id);
            return cidade;
        }

        public Cidade ObterPorId(int id)
        {
            Cidade cidade = db.Cidades.Find(id);
            return cidade;
        }

        #region Validações

        public void ValidaAdicionar(Cidade domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Cidade domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Cidade domain)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
