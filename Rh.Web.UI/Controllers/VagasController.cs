using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Rh.Dominio;
using Rh.ORM;
using System;
using Rh.Negocio;

namespace Rh.Web.UI.Controllers
{
    public class VagasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Vagas
        public ActionResult Index()
        {
            return View(db.Vagas.ToList());
        }

        // GET: Vagas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vagaBo = new VagaBo();
            var vaga = vagaBo.Mostrar(id.Value);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        // GET: Vagas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vagas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VagaId,Nome,Descricao,Situacao,DataCadastro")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                var vagaBo = new VagaBo();
                vagaBo.Adicionar(vaga);
                return RedirectToAction("Index");
            }

            return View(vaga);
        }

        // GET: Vagas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vagaBo = new VagaBo();
            var vaga = vagaBo.ObterPorId(id.Value);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        // POST: Vagas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VagaId,Nome,Descricao,Situacao,DataCadastro")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                var vagaBo = new VagaBo();
                vagaBo.Editar(vaga);
                return RedirectToAction("Index");
            }
            return View(vaga);
        }

        // GET: Vagas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vagaBo = new VagaBo();
            var vaga = vagaBo.ObterPorId(id.Value);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var vagaBo = new VagaBo();
            vagaBo.Apagar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
