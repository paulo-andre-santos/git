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
    public class TipoNumeroTelefonesController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        TipoNumeroTelefoneDao dao = new TipoNumeroTelefoneDao();

        // GET: TipoNumeroTelefones
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: TipoNumeroTelefones/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNumeroTelefone tipoNumeroTelefone = dao.Buscar(id);
            if (tipoNumeroTelefone == null)
            {
                return HttpNotFound();
            }
            return View(tipoNumeroTelefone);
        }

        // GET: TipoNumeroTelefones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoNumeroTelefones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoNumeroTelefoneID,Nome,DataModificacao")] TipoNumeroTelefone tipoNumeroTelefone)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(tipoNumeroTelefone);
                return RedirectToAction("Index");
            }

            return View(tipoNumeroTelefone);
        }

        // GET: TipoNumeroTelefones/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNumeroTelefone tipoNumeroTelefone = dao.Buscar(id);
            if (tipoNumeroTelefone == null)
            {
                return HttpNotFound();
            }
            return View(tipoNumeroTelefone);
        }

        // POST: TipoNumeroTelefones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoNumeroTelefoneID,Nome,DataModificacao")] TipoNumeroTelefone tipoNumeroTelefone)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(tipoNumeroTelefone);
                return RedirectToAction("Index");
            }
            return View(tipoNumeroTelefone);
        }

        // GET: TipoNumeroTelefones/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNumeroTelefone tipoNumeroTelefone = dao.Buscar(id);
            if (tipoNumeroTelefone == null)
            {
                return HttpNotFound();
            }
            return View(tipoNumeroTelefone);
        }

        // POST: TipoNumeroTelefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoNumeroTelefone tipoNumeroTelefone = dao.Buscar(id);
            bool valido = dao.Deletar(tipoNumeroTelefone);
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
