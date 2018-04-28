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
    public class EntidadeDeNegociosController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        EntidadeDeNegocioDao dao = new EntidadeDeNegocioDao();

        // GET: EntidadeDeNegocios
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: EntidadeDeNegocios/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntidadeDeNegocio entidadeDeNegocio = dao.Buscar(id);
            if (entidadeDeNegocio == null)
            {
                return HttpNotFound();
            }
            return View(entidadeDeNegocio);
        }

        // GET: EntidadeDeNegocios/Create
        public ActionResult Create()
        {
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa");
            return View();
        }

        // POST: EntidadeDeNegocios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntidadeDeNegocioID")] EntidadeDeNegocio entidadeDeNegocio)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(entidadeDeNegocio);
                return RedirectToAction("Index");
            }

            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", entidadeDeNegocio.EntidadeDeNegocioID);
            return View(entidadeDeNegocio);
        }

        // GET: EntidadeDeNegocios/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntidadeDeNegocio entidadeDeNegocio = dao.Buscar(id);
            if (entidadeDeNegocio == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", entidadeDeNegocio.EntidadeDeNegocioID);
            return View(entidadeDeNegocio);
        }

        // POST: EntidadeDeNegocios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntidadeDeNegocioID")] EntidadeDeNegocio entidadeDeNegocio)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(entidadeDeNegocio);
                return RedirectToAction("Index");
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", entidadeDeNegocio.EntidadeDeNegocioID);
            return View(entidadeDeNegocio);
        }

        // GET: EntidadeDeNegocios/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntidadeDeNegocio entidadeDeNegocio = dao.Buscar(id);
            if (entidadeDeNegocio == null)
            {
                return HttpNotFound();
            }
            return View(entidadeDeNegocio);
        }

        // POST: EntidadeDeNegocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntidadeDeNegocio entidadeDeNegocio = dao.Buscar(id);
            bool valido = dao.Deletar(entidadeDeNegocio);
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
