using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModuloPessoa;
using ModuloPessoa.Dao;

namespace ModuloPessoa.Controllers
{
    public class EnderecoEmailController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        EnderecoEmailDao dao = new EnderecoEmailDao();

        // GET: EnderecoEmail
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: EnderecoEmail/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEmail enderecoEmail = dao.Buscar(id);
            if (enderecoEmail == null)
            {
                return HttpNotFound();
            }
            return View(enderecoEmail);
        }

        // GET: EnderecoEmail/Create
        public ActionResult Create()
        {
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa");
            return View();
        }

        // POST: EnderecoEmail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntidadeDeNegocioID,EnderecoEmailID,Email")] EnderecoEmail enderecoEmail)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(enderecoEmail);
                return RedirectToAction("Index");
            }

            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", enderecoEmail.EntidadeDeNegocioID);
            return View(enderecoEmail);
        }

        // GET: EnderecoEmail/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEmail enderecoEmail = dao.Buscar(id);
            if (enderecoEmail == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", enderecoEmail.EntidadeDeNegocioID);
            return View(enderecoEmail);
        }

        // POST: EnderecoEmail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntidadeDeNegocioID,EnderecoEmailID,Email")] EnderecoEmail enderecoEmail)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(enderecoEmail);
                return RedirectToAction("Index");
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", enderecoEmail.EntidadeDeNegocioID);
            return View(enderecoEmail);
        }

        // GET: EnderecoEmail/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEmail enderecoEmail = dao.Buscar(id);
            if (enderecoEmail == null)
            {
                return HttpNotFound();
            }
            return View(enderecoEmail);
        }

        // POST: EnderecoEmail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            EnderecoEmail enderecoEmail = dao.Buscar(id);
            bool valido = dao.Deletar(enderecoEmail);
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
