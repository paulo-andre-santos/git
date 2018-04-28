using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModuloPessoa;

namespace ModuloPessoa.Controllers
{
    public class ContatoEntidadeDeNegociosController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        ContatoEntidadeDeNegocioDao dao = new ContatoEntidadeDeNegocioDao();

        // GET: ContatoEntidadeDeNegocios
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: ContatoEntidadeDeNegocios/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoEntidadeDeNegocio contatoEntidadeDeNegocio = dao.Buscar(id);
            if (contatoEntidadeDeNegocio == null)
            {
                return HttpNotFound();
            }
            return View(contatoEntidadeDeNegocio);
        }

        // GET: ContatoEntidadeDeNegocios/Create
        public ActionResult Create()
        {
            ViewBag.EntidadeDeNegocioID = new SelectList(db.EntidadeDeNegocio, "EntidadeDeNegocioID", "EntidadeDeNegocioID");
            ViewBag.PessoaID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa");
            ViewBag.TipoContatoID = new SelectList(db.TipoContato, "TipoContato1", "Nome");
            return View();
        }

        // POST: ContatoEntidadeDeNegocios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntidadeDeNegocioID,PessoaID,TipoContatoID,rowguid,DataModificacao")] ContatoEntidadeDeNegocio contatoEntidadeDeNegocio)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(contatoEntidadeDeNegocio);
                return RedirectToAction("Index");
            }

            ViewBag.EntidadeDeNegocioID = new SelectList(db.EntidadeDeNegocio, "EntidadeDeNegocioID", "EntidadeDeNegocioID", contatoEntidadeDeNegocio.EntidadeDeNegocioID);
            ViewBag.PessoaID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", contatoEntidadeDeNegocio.PessoaID);
            ViewBag.TipoContatoID = new SelectList(db.TipoContato, "TipoContato1", "Nome", contatoEntidadeDeNegocio.TipoContatoID);
            return View(contatoEntidadeDeNegocio);
        }

        // GET: ContatoEntidadeDeNegocios/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoEntidadeDeNegocio contatoEntidadeDeNegocio = dao.Buscar(id);
            if (contatoEntidadeDeNegocio == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.EntidadeDeNegocio, "EntidadeDeNegocioID", "EntidadeDeNegocioID", contatoEntidadeDeNegocio.EntidadeDeNegocioID);
            ViewBag.PessoaID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", contatoEntidadeDeNegocio.PessoaID);
            ViewBag.TipoContatoID = new SelectList(db.TipoContato, "TipoContato1", "Nome", contatoEntidadeDeNegocio.TipoContatoID);
            return View(contatoEntidadeDeNegocio);
        }

        // POST: ContatoEntidadeDeNegocios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntidadeDeNegocioID,PessoaID,TipoContatoID,rowguid,DataModificacao")] ContatoEntidadeDeNegocio contatoEntidadeDeNegocio)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(contatoEntidadeDeNegocio);
                return RedirectToAction("Index");
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.EntidadeDeNegocio, "EntidadeDeNegocioID", "EntidadeDeNegocioID", contatoEntidadeDeNegocio.EntidadeDeNegocioID);
            ViewBag.PessoaID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", contatoEntidadeDeNegocio.PessoaID);
            ViewBag.TipoContatoID = new SelectList(db.TipoContato, "TipoContato1", "Nome", contatoEntidadeDeNegocio.TipoContatoID);
            return View(contatoEntidadeDeNegocio);
        }

        // GET: ContatoEntidadeDeNegocios/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoEntidadeDeNegocio contatoEntidadeDeNegocio = dao.Buscar(id);
            if (contatoEntidadeDeNegocio == null)
            {
                return HttpNotFound();
            }
            return View(contatoEntidadeDeNegocio);
        }

        // POST: ContatoEntidadeDeNegocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ContatoEntidadeDeNegocio contatoEntidadeDeNegocio = dao.Buscar(id);
            bool valido = dao.Deletar(contatoEntidadeDeNegocio);
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
