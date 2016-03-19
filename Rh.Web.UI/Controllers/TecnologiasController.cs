using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Rh.Dominio;
using Rh.ORM;
using Rh.Negocio;

namespace Rh.Web.UI.Controllers
{
    public class TecnologiasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Tecnologias
        public ActionResult Index()
        {
            return View(db.Tecnologias.ToList());
        }

        // GET: Tecnologias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tecnologiaBo = new TecnologiaBo();
            var tecnologia = tecnologiaBo.Mostrar(id.Value);
            if (tecnologia == null)
            {
                return HttpNotFound();
            }
            return View(tecnologia);
        }

        // GET: Tecnologias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecnologias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TecnologiaId,Nome,Descricao,Peso")] Tecnologia tecnologia)
        {
            if (ModelState.IsValid)
            {
                var tecnologiaBo = new TecnologiaBo();
                tecnologiaBo.Adicionar(tecnologia);
                return RedirectToAction("Index");
            }

            return View(tecnologia);
        }

        // GET: Tecnologias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tecnologiaBo = new TecnologiaBo();
            var tecnologia = tecnologiaBo.ObterPorId(id.Value);
            if (tecnologia == null)
            {
                return HttpNotFound();
            }
            return View(tecnologia);
        }

        // POST: Tecnologias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TecnologiaId,Nome,Descricao,Peso")] Tecnologia tecnologia)
        {
            if (ModelState.IsValid)
            {
                var tecnologiaBo = new TecnologiaBo();
                tecnologiaBo.Editar(tecnologia);
                return RedirectToAction("Index");
            }
            return View(tecnologia);
        }

        // GET: Tecnologias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tecnologiaBo = new TecnologiaBo();
            var tecnologia = tecnologiaBo.ObterPorId(id.Value);
            if (tecnologia == null)
            {
                return HttpNotFound();
            }
            return View(tecnologia);
        }

        // POST: Tecnologias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tecnologiaBo = new TecnologiaBo();
            tecnologiaBo.Apagar(id);
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
