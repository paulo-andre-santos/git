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
    public class EnderecoEntidadeDeNegociosController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        EnderecoEntidadeDeNegocioDao dao = new EnderecoEntidadeDeNegocioDao();

        // GET: EnderecoEntidadeDeNegocios
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: EnderecoEntidadeDeNegocios/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEntidadeDeNegocio enderecoEntidadeDeNegocio = dao.Buscar(id);
            if (enderecoEntidadeDeNegocio == null)
            {
                return HttpNotFound();
            }
            return View(enderecoEntidadeDeNegocio);
        }

        // GET: EnderecoEntidadeDeNegocios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnderecoEntidadeDeNegocios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntidadeNegocioID,EnderecoID,TipoEnderecoID")] EnderecoEntidadeDeNegocio enderecoEntidadeDeNegocio)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Criar(enderecoEntidadeDeNegocio);
                return RedirectToAction("Index");
            }

            return View(enderecoEntidadeDeNegocio);
        }

        // GET: EnderecoEntidadeDeNegocios/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEntidadeDeNegocio enderecoEntidadeDeNegocio = dao.Buscar(id);
            if (enderecoEntidadeDeNegocio == null)
            {
                return HttpNotFound();
            }
            return View(enderecoEntidadeDeNegocio);
        }

        // POST: EnderecoEntidadeDeNegocios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntidadeNegocioID,EnderecoID")] EnderecoEntidadeDeNegocio enderecoEntidadeDeNegocio)
        {
            if (ModelState.IsValid)
            {
                bool valido = dao.Editar(enderecoEntidadeDeNegocio);
                return RedirectToAction("Index");
            }
            return View(enderecoEntidadeDeNegocio);
        }

        // GET: EnderecoEntidadeDeNegocios/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEntidadeDeNegocio enderecoEntidadeDeNegocio = dao.Buscar(id);
            if (enderecoEntidadeDeNegocio == null)
            {
                return HttpNotFound();
            }
            return View(enderecoEntidadeDeNegocio);
        }

        // POST: EnderecoEntidadeDeNegocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnderecoEntidadeDeNegocio enderecoEntidadeDeNegocio = dao.Buscar(id);
            bool valido = dao.Deletar(enderecoEntidadeDeNegocio);
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
