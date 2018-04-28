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
    public class TelefonePessoasController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        TelefonePessoaDao dao = new TelefonePessoaDao();

        // GET: TelefonePessoas
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: TelefonePessoas/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelefonePessoa telefonePessoa = dao.Buscar(id);
            if (telefonePessoa == null)
            {
                return HttpNotFound();
            }
            return View(telefonePessoa);
        }

        // GET: TelefonePessoas/Create
        public ActionResult Create()
        {
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa");
            ViewBag.TipoNumeroTelefoneID = new SelectList(db.TipoNumeroTelefone, "TipoNumeroTelefoneID", "Nome");
            return View();
        }

        // POST: TelefonePessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntidadeDeNegocioID,NumeroTelefone,TipoNumeroTelefoneID")] TelefonePessoa telefonePessoa)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(telefonePessoa);        
                return RedirectToAction("Index");
            }

            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", telefonePessoa.EntidadeDeNegocioID);
            ViewBag.TipoNumeroTelefoneID = new SelectList(db.TipoNumeroTelefone, "TipoNumeroTelefoneID", "Nome", telefonePessoa.TipoNumeroTelefoneID);
            return View(telefonePessoa);
        }

        // GET: TelefonePessoas/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelefonePessoa telefonePessoa = dao.Buscar(id);
            if (telefonePessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", telefonePessoa.EntidadeDeNegocioID);
            ViewBag.TipoNumeroTelefoneID = new SelectList(db.TipoNumeroTelefone, "TipoNumeroTelefoneID", "Nome", telefonePessoa.TipoNumeroTelefoneID);
            return View(telefonePessoa);
        }

        // POST: TelefonePessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntidadeDeNegocioID,NumeroTelefone,TipoNumeroTelefoneID")] TelefonePessoa telefonePessoa)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(telefonePessoa);
                return RedirectToAction("Index");
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", telefonePessoa.EntidadeDeNegocioID);
            ViewBag.TipoNumeroTelefoneID = new SelectList(db.TipoNumeroTelefone, "TipoNumeroTelefoneID", "Nome", telefonePessoa.TipoNumeroTelefoneID);
            return View(telefonePessoa);
        }

        // GET: TelefonePessoas/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelefonePessoa telefonePessoa = dao.Buscar(id);
            if (telefonePessoa == null)
            {
                return HttpNotFound();
            }
            return View(telefonePessoa);
        }

        // POST: TelefonePessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TelefonePessoa telefonePessoa = dao.Buscar(id);
            bool valido = dao.Deletar(telefonePessoa);
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
