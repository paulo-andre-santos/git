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
    public class PessoasController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        PessoaDao dao = new PessoaDao();

        // GET: Pessoas
        public ActionResult Index()
        {            
            return View(dao.Listar);
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = dao.Buscar(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            ViewBag.EntidadeDeNegocioID = new SelectList(db.EntidadeDeNegocio, "EntidadeDeNegocioID", "EntidadeDeNegocioID");
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Senha, "EntidadeDeNegocioID", "SenhaHash");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntidadeDeNegocioID,TipoPessoa,EstiloNome,Titulo,PrimeiroNome,NomeDoMeio,UltimoNome,Sufixo,EmailPromocional,InfoContatoAdicional,Demografia,rowguid,DataModificacao")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Buscar(pessoa);      
                return RedirectToAction("Index");
            }

            ViewBag.EntidadeDeNegocioID = new SelectList(db.EntidadeDeNegocio, "EntidadeDeNegocioID", "EntidadeDeNegocioID", pessoa.EntidadeDeNegocioID);
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Senha, "EntidadeDeNegocioID", "SenhaHash", pessoa.EntidadeDeNegocioID);
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = dao.Buscar(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.EntidadeDeNegocio, "EntidadeDeNegocioID", "EntidadeDeNegocioID", pessoa.EntidadeDeNegocioID);
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Senha, "EntidadeDeNegocioID", "SenhaHash", pessoa.EntidadeDeNegocioID);
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntidadeDeNegocioID,TipoPessoa,EstiloNome,Titulo,PrimeiroNome,NomeDoMeio,UltimoNome,Sufixo,EmailPromocional,InfoContatoAdicional,Demografia,rowguid,DataModificacao")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(pessoa);
                return RedirectToAction("Index");
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.EntidadeDeNegocio, "EntidadeDeNegocioID", "EntidadeDeNegocioID", pessoa.EntidadeDeNegocioID);
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Senha, "EntidadeDeNegocioID", "SenhaHash", pessoa.EntidadeDeNegocioID);
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = dao.Buscar(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = dao.Buscar(id);
            dao.Deletar(pessoa);
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
