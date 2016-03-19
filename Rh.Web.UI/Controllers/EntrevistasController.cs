using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Rh.Dominio;
using Rh.ORM;
using Rh.Negocio;

namespace Rh.Web.UI.Controllers
{
    public class EntrevistasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Entrevistas
        public ActionResult Index()
        {
            var entrevistas = db.Entrevistas.Include(e => e.Candidato).Include(e => e.Vaga);
            return View(entrevistas.ToList());
        }

        // GET: Entrevistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entrevistaBo = new EntrevistaBo();
            var entrevista = entrevistaBo.Mostrar(id.Value);
            if (entrevista == null)
            {
                return HttpNotFound();
            }
            return View(entrevista);
        }

        // GET: Entrevistas/Create
        public ActionResult Create()
        {
            ViewBag.CandidatoId = new SelectList(db.Candidatos, "CandidatoId", "Nome");
            ViewBag.VagaId = new SelectList(db.Vagas, "VagaId", "Nome");
            return View();
        }

        // POST: Entrevistas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntrevistaId,Nota,Comentario,DataEntrevista,VagaId,CandidatoId")] Entrevista entrevista)
        {
            if (ModelState.IsValid)
            {
                var entrevistaBo = new EntrevistaBo();
                entrevistaBo.Adicionar(entrevista);
                return RedirectToAction("Index");
            }

            ViewBag.CandidatoId = new SelectList(db.Candidatos, "CandidatoId", "Nome", entrevista.CandidatoId);
            ViewBag.VagaId = new SelectList(db.Vagas, "VagaId", "Nome", entrevista.VagaId);
            return View(entrevista);
        }

        // GET: Entrevistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entrevistaBo = new EntrevistaBo();
            var entrevista = entrevistaBo.ObterPorId(id.Value);
            if (entrevista == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidatoId = new SelectList(db.Candidatos, "CandidatoId", "Nome", entrevista.CandidatoId);
            ViewBag.VagaId = new SelectList(db.Vagas, "VagaId", "Nome", entrevista.VagaId);
            return View(entrevista);
        }

        // POST: Entrevistas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntrevistaId,Nota,Comentario,DataEntrevista,VagaId,CandidatoId")] Entrevista entrevista)
        {
            if (ModelState.IsValid)
            {
                var entrevistaBo = new EntrevistaBo();
                entrevistaBo.Editar(entrevista);
                return RedirectToAction("Index");
            }
            ViewBag.CandidatoId = new SelectList(db.Candidatos, "CandidatoId", "Nome", entrevista.CandidatoId);
            ViewBag.VagaId = new SelectList(db.Vagas, "VagaId", "Nome", entrevista.VagaId);
            return View(entrevista);
        }

        // GET: Entrevistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entrevistaBo = new EntrevistaBo();
            var entrevista = entrevistaBo.ObterPorId(id.Value);
            if (entrevista == null)
            {
                return HttpNotFound();
            }
            return View(entrevista);
        }

        // POST: Entrevistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var entrevistaBo = new EntrevistaBo();
            entrevistaBo.Apagar(id);
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
