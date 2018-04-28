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
    public class TipoContatosController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        TipoContatoDao dao = new TipoContatoDao();

        // GET: TipoContatos
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: TipoContatos/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContato tipoContato = dao.Buscar(id);
            if (tipoContato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContato);
        }

        // GET: TipoContatos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoContatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoContato1,Nome")] TipoContato tipoContato)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(tipoContato);
                return RedirectToAction("Index");
            }

            return View(tipoContato);
        }

        // GET: TipoContatos/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContato tipoContato = dao.Buscar(id);
            if (tipoContato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContato);
        }

        // POST: TipoContatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoContato1,Nome")] TipoContato tipoContato)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(tipoContato);
                return RedirectToAction("Index");
            }
            return View(tipoContato);
        }

        // GET: TipoContatos/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContato tipoContato = dao.Buscar(id);
            if (tipoContato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContato);
        }

        // POST: TipoContatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoContato tipoContato = dao.Buscar(id);
            bool valido = dao.Deletar(tipoContato);
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
