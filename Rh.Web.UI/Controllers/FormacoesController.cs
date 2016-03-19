using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Rh.Dominio;
using Rh.ORM;
using Rh.Negocio;

namespace Rh.Web.UI.Controllers
{
    public class FormacoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Formacoes
        public ActionResult Index()
        {
            return View(db.Formacoes.ToList());
        }

        // GET: Formacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var formacaoBo = new FormacaoBo();
            var formacao = formacaoBo.Mostrar(id.Value);
            if (formacao == null)
            {
                return HttpNotFound();
            }
            return View(formacao);
        }

        // GET: Formacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formacoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormacaoId,Curso,Instituicao,Descricao,Conclusao,CadidatoId")] Formacao formacao)
        {
            if (ModelState.IsValid)
            {
                var formacaoBo = new FormacaoBo();
                formacaoBo.Adicionar(formacao);
                return RedirectToAction("Index");
            }

            return View(formacao);
        }

        // GET: Formacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var formacaoBo = new FormacaoBo();
            var formacao = formacaoBo.ObterPorId(id.Value);
            if (formacao == null)
            {
                return HttpNotFound();
            }
            return View(formacao);
        }

        // POST: Formacoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormacaoId,Curso,Instituicao,Descricao,Conclusao,CadidatoId")] Formacao formacao)
        {
            if (ModelState.IsValid)
            {
                var formacaoBo = new FormacaoBo();
                formacaoBo.Editar(formacao);
                return RedirectToAction("Index");
            }
            return View(formacao);
        }

        // GET: Formacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var formacaoBo = new FormacaoBo();
            var formacao = formacaoBo.ObterPorId(id.Value);
            if (formacao == null)
            {
                return HttpNotFound();
            }
            return View(formacao);
        }

        // POST: Formacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var formacaoBo = new FormacaoBo();
            formacaoBo.Apagar(id);
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
