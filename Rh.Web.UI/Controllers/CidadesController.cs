using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Rh.Dominio;
using Rh.ORM;
using Rh.Negocio;

namespace Rh.Web.UI.Controllers
{
    public class CidadesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Cidades
        public ActionResult Index()
        {
            var cidades = db.Cidades.Include(c => c.Estado);
            return View(cidades.ToList());
        }

        // GET: Cidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cidadeBo = new CidadeBo();
            var cidade = cidadeBo.Mostrar(id.Value);

            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: Cidades/Create
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome");
            return View();
        }

        // POST: Cidades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CidadeId,Nome,EstadoId")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                var cidadeBo = new CidadeBo();
                cidadeBo.Adicionar(cidade);
                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome", cidade.EstadoId);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cidadeBo = new CidadeBo();
            var cidade = cidadeBo.ObterPorId(id.Value);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome", cidade.EstadoId);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CidadeId,Nome,EstadoId")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                var cidadeBo = new CidadeBo();
                cidadeBo.Editar(cidade);
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome", cidade.EstadoId);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cidadeBo = new CidadeBo();
            var cidade = cidadeBo.ObterPorId(id.Value);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cidadeBo = new CidadeBo();
            cidadeBo.Apagar(id);
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
