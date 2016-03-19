using System;
using Rh.Dominio;
using Rh.Negocio.Interfaces;
using Rh.ORM;
using System.Data.Entity;

namespace Rh.Negocio
{
    public class VagaBo : IVagaBo
    {
        private Contexto db = new Contexto();

        public void Adicionar(Vaga vaga)
        {
            vaga.DataCadastro = DateTime.Now.ToLocalTime();
            db.Vagas.Add(vaga);
            db.SaveChanges();
        }

        public void Apagar(int id)
        {
            Vaga vaga = db.Vagas.Find(id);
            db.Vagas.Remove(vaga);
            db.SaveChanges();
        }

        public void Editar(Vaga vaga)
        {
            db.Entry(vaga).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Vaga Mostrar(int id)
        {
            Vaga vaga = db.Vagas.Find(id);
            return vaga;
        }

        public Vaga ObterPorId(int id)
        {
            Vaga vaga = db.Vagas.Find(id);
            return vaga;
        }

        #region Validações
        public void ValidaAdicionar(Vaga domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaApagar(Vaga domain)
        {
            throw new NotImplementedException();
        }

        public void ValidaEditar(Vaga domain)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
