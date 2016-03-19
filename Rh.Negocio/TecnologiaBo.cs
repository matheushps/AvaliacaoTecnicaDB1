using System;
using Rh.Dominio;
using Rh.Negocio.Interfaces;
using Rh.ORM;
using System.Data.Entity;

namespace Rh.Negocio
{
    public class TecnologiaBo : ITecnologiaBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Tecnologia tecnologia)
        {
            db.Tecnologias.Add(tecnologia);
            db.SaveChanges();
        }

        public void Apagar(int id)
        {
            Tecnologia tecnologia = db.Tecnologias.Find(id);
            db.Tecnologias.Remove(tecnologia);
            db.SaveChanges();
        }

        public void Editar(Tecnologia tecnologia)
        {
            db.Entry(tecnologia).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Tecnologia Mostrar(int id)
        {
            Tecnologia tecnologia = db.Tecnologias.Find(id);
            return tecnologia;
        }

        public Tecnologia ObterPorId(int id)
        {
            Tecnologia tecnologias = db.Tecnologias.Find(id);
            return tecnologias;
        }
        #region Validações

        public void ValidaAdicionar(Tecnologia domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Tecnologia domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Tecnologia domain)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
