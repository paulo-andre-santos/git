using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModuloPessoa;
using ModuloSenha.Dao;

namespace ModuloPessoa.Controllers
{
    public class SenhasController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        SenhaDao dao = new SenhaDao();

        // GET: Senhas
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: Senhas/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Senha senha = dao.Buscar(id);
            if (senha == null)
            {
                return HttpNotFound();
            }
            return View(senha);
        }

        // GET: Senhas/Create
        public ActionResult Create()
        {
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa");
            return View();
        }

        // POST: Senhas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntidadeDeNegocioID,SenhaHash,SenhaSalt")] Senha senha)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(senha);
                db.Senha.Add(senha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", senha.EntidadeDeNegocioID);
            return View(senha);
        }

        // GET: Senhas/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Senha senha = dao.Buscar(id);
            if (senha == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", senha.EntidadeDeNegocioID);
            return View(senha);
        }

        // POST: Senhas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntidadeDeNegocioID,SenhaHash,SenhaSalt")] Senha senha)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(senha);
                return RedirectToAction("Index");
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", senha.EntidadeDeNegocioID);
            return View(senha);
        }

        // GET: Senhas/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Senha senha = dao.Buscar(id);
            if (senha == null)
            {
                return HttpNotFound();
            }
            return View(senha);
        }

        // POST: Senhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Senha senha = dao.Buscar(id);
            bool valido = dao.Criar(senha);
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
