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
    public class TipoEnderecosController : Controller
    {
        private PessoaConnection db = new PessoaConnection();
        TipoEnderecoDao dao = new TipoEnderecoDao();

        // GET: TipoEnderecos
        public ActionResult Index()
        {
            return View(dao.Listar);
        }

        // GET: TipoEnderecos/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEndereco tipoEndereco = dao.Buscar(id);
            if (tipoEndereco == null)
            {
                return HttpNotFound();
            }
            return View(tipoEndereco);
        }

        // GET: TipoEnderecos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEnderecos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,DataModificacao")] TipoEndereco tipoEndereco)
        {
            if (ModelState.IsValid)
            {
                //db.TipoEndereco.Add(tipoEndereco);
                //db.SaveChanges();
                bool valido = dao.Criar(tipoEndereco);
                return RedirectToAction("Index");
            }

            return View(tipoEndereco);
        }

        // GET: TipoEnderecos/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEndereco tipoEndereco = dao.Buscar(id); 
            if (tipoEndereco == null)
            {
                return HttpNotFound();
            }
            return View(tipoEndereco);
        }

        // POST: TipoEnderecos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nome,DataModificacao")] TipoEndereco tipoEndereco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tipoEndereco).State = EntityState.Modified;
                //db.SaveChanges();
                bool valido = dao.Editar(tipoEndereco);
                return RedirectToAction("Index");
            }
            return View(tipoEndereco);
        }

        // GET: TipoEnderecos/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEndereco tipoEndereco = dao.Buscar(id);
            if (tipoEndereco == null)
            {
                return HttpNotFound();
            }
            return View(tipoEndereco);
        }

        // POST: TipoEnderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEndereco tipoEndereco = dao.Buscar(id);
            bool valido = dao.Deletar(tipoEndereco);
            //db.TipoEndereco.Remove(tipoEndereco);
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
