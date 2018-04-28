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
    public class EnderecosController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        EnderecoDao dao = new EnderecoDao();

        // GET: Enderecos
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: Enderecos/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = dao.Buscar(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Enderecos/Create
        public ActionResult Create()
        {
            ViewBag.EstadoProvinciaID = new SelectList(db.EstadoProvincia, "EstadoProvinciaID", "CodigoEstadoProvincia");
            return View();
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnderecoID,Endereco1,Endereco2,Cidade,EstadoProvinciaID,CodigoPostal")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(endereco);
                return RedirectToAction("Index");
            }

            ViewBag.EstadoProvinciaID = new SelectList(db.EstadoProvincia, "EstadoProvinciaID", "CodigoEstadoProvincia", endereco.EstadoProvinciaID);
            return View(endereco);
        }

        // GET: Enderecos/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = dao.Buscar(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoProvinciaID = new SelectList(db.EstadoProvincia, "EstadoProvinciaID", "CodigoEstadoProvincia", endereco.EstadoProvinciaID);
            return View(endereco);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnderecoID,Endereco1,Endereco2,Cidade,EstadoProvinciaID,CodigoPostal")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(endereco);
                return RedirectToAction("Index");
            }
            ViewBag.EstadoProvinciaID = new SelectList(db.EstadoProvincia, "EstadoProvinciaID", "CodigoEstadoProvincia", endereco.EstadoProvinciaID);
            return View(endereco);
        }

        // GET: Enderecos/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = dao.Buscar(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = dao.Buscar(id);
            dao.Deletar(endereco);
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
