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
    public class EstadoProvinciasController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        EstadoProvinciaDao dao = new EstadoProvinciaDao();

        // GET: EstadoProvincias
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: EstadoProvincias/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoProvincia estadoProvincia = dao.Buscar(id);
            if (estadoProvincia == null)
            {
                return HttpNotFound();
            }
            return View(estadoProvincia);
        }

        // GET: EstadoProvincias/Create
        public ActionResult Create()
        {
            ViewBag.CodigoRegiao = new SelectList(db.Regiao, "CodigoRegiao", "Nome");
            return View();
        }

        // POST: EstadoProvincias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoProvinciaID,CodigoEstadoProvincia,CodigoRegiao,SomenteEstadoProvinciaFlag,Nome")] EstadoProvincia estadoProvincia)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(estadoProvincia);
                return RedirectToAction("Index");
            }

            ViewBag.CodigoRegiao = new SelectList(db.Regiao, "CodigoRegiao", "Nome", estadoProvincia.CodigoRegiao);
            return View(estadoProvincia);
        }

        // GET: EstadoProvincias/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoProvincia estadoProvincia = dao.Buscar(id);
            if (estadoProvincia == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoRegiao = new SelectList(db.Regiao, "CodigoRegiao", "Nome", estadoProvincia.CodigoRegiao);
            return View(estadoProvincia);
        }

        // POST: EstadoProvincias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoProvinciaID,CodigoEstadoProvincia,CodigoRegiao,SomenteEstadoProvinciaFlag,Nome,rowguid,DataModificacao")] EstadoProvincia estadoProvincia)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(estadoProvincia);
                return RedirectToAction("Index");
            }
            ViewBag.CodigoRegiao = new SelectList(db.Regiao, "CodigoRegiao", "Nome", estadoProvincia.CodigoRegiao);
            return View(estadoProvincia);
        }

        // GET: EstadoProvincias/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoProvincia estadoProvincia = dao.Buscar(id);
            if (estadoProvincia == null)
            {
                return HttpNotFound();
            }
            return View(estadoProvincia);
        }

        // POST: EstadoProvincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoProvincia estadoProvincia = dao.Buscar(id);
            dao.Deletar(estadoProvincia);
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
