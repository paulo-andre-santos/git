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
    public class RegioesController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        RegiaoDao dao = new RegiaoDao();

        // GET: Regioes
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: Regioes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiao regiao = dao.Buscar(id);
            if (regiao == null)
            {
                return HttpNotFound();
            }
            return View(regiao);
        }

        // GET: Regioes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regioes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoRegiao,Nome")] Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(regiao);
                return RedirectToAction("Index");
            }

            return View(regiao);
        }

        // GET: Regioes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiao regiao = dao.Buscar(id);
            if (regiao == null)
            {
                return HttpNotFound();
            }
            return View(regiao);
        }

        // POST: Regioes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoRegiao,Nome")] Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(regiao);
                return RedirectToAction("Index");
            }
            return View(regiao);
        }

        // GET: Regioes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiao regiao = dao.Buscar(id);
            if (regiao == null)
            {
                return HttpNotFound();
            }
            return View(regiao);
        }

        // POST: Regioes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Regiao regiao = dao.Buscar(id);
            bool valido = dao.Deletar(regiao);
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
