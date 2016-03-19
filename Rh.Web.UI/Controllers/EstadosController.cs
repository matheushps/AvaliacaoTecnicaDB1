using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Rh.Dominio;
using Rh.ORM;
using Rh.Negocio;

namespace Rh.Web.UI.Controllers
{
    public class EstadosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Estados
        public ActionResult Index()
        {
            return View(db.Estados.ToList());
        }

        // GET: Estados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estadoBo = new EstadoBo();
            var estado = estadoBo.Mostrar(id.Value);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // GET: Estados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estados/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoId,Nome")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                var estadoBo = new EstadoBo();
                estadoBo.Adicionar(estado);
                return RedirectToAction("Index");
            }

            return View(estado);
        }

        // GET: Estados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estadoBo = new EstadoBo();
            var estado = estadoBo.ObterPorId(id.Value);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // POST: Estados/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoId,Nome")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                var estadoBo = new EstadoBo();
                estadoBo.Editar(estado);
                return RedirectToAction("Index");
            }
            return View(estado);
        }

        // GET: Estados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estadoBo = new EstadoBo();
            var estado = estadoBo.ObterPorId(id.Value);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var estadoBo = new EstadoBo();
            estadoBo.Apagar(id);
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
