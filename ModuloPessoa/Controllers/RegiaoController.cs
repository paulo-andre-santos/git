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
    public class RegiaoController : Controller
    {
        private PessoaConnection db = new PessoaConnection();        
        RegiaoDao dao = new RegiaoDao();
        // GET: Regiao
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: Regiao/Details/5
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

        // GET: Regiao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regiao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoRegiao,Nome,DataModificacao")] Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                bool teste = dao.Criar(regiao);
                return RedirectToAction("Index");
            }

            return View(regiao);
        }

        // GET: Regiao/Edit/5
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

        // POST: Regiao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoRegiao,Nome,DataModificacao")] Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(regiao).State = EntityState.Modified;
                //db.SaveChanges();
                bool valido = dao.Editar(regiao);
                return RedirectToAction("Index");
            }
            return View(regiao);
        }

        // GET: Regiao/Delete/5
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

        // POST: Regiao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Regiao regiao = dao.Buscar(id);
            bool valido = dao.Deletar(regiao);
            //db.Regiao.Remove(regiao);
            //db.SaveChanges();
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
