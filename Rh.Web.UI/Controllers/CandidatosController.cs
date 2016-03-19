using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Rh.Dominio;
using Rh.ORM;
using System;
using Rh.Negocio.Interfaces;
using Rh.Negocio;

namespace Rh.Web.UI.Controllers
{
    public class CandidatosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Candidatos
        public ActionResult Index()
        {
            var candidatos = db.Candidatos.Include(c => c.Cidade);
            return View(candidatos.ToList());
        }

        // GET: Candidatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var candidatoBo = new CandidatoBo();
            var candidato = candidatoBo.Mostrar(id.Value);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // GET: Candidatos/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidades, "CidadeId", "Nome");
            return View();
        }

        // POST: Candidatos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidatoId,Nome,Email,DataNascimento,Telefone,Celular,CidadeId,DataCadastro")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                var candidatoBo = new CandidatoBo();
                candidatoBo.Adicionar(candidato);
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(db.Cidades, "CidadeId", "Nome", candidato.CidadeId);
            return View(candidato);
        }

        // GET: Candidatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var candidatoBo = new CandidatoBo();
            var candidato = candidatoBo.ObterPorId(id.Value);

            if (candidato == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "CidadeId", "Nome", candidato.CidadeId);
            return View(candidato);
        }

        // POST: Candidatos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidatoId,Nome,Email,DataNascimento,Telefone,Celular,CidadeId,DataCadastro")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                var candidatoBo = new CandidatoBo();
                candidatoBo.Editar(candidato);
                return RedirectToAction("Index");
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "CidadeId", "Nome", candidato.CidadeId);
            return View(candidato);
        }

        // GET: Candidatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var candidatoBo = new CandidatoBo();
            var candidato = candidatoBo.ObterPorId(id.Value);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var candidatoBo = new CandidatoBo();
            candidatoBo.Apagar(id);
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
