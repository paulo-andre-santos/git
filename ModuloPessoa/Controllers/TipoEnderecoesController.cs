using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModuloPessoa;

namespace ModuloPessoa.Controllers
{
    public class TipoEnderecoesController : Controller
    {
        private PessoaConnection db = new PessoaConnection();

        // GET: TipoEnderecoes
        public ActionResult Index()
        {
            return View(db.TipoEndereco.ToList());
        }

        public List<TipoEndereco> tiporeturn()
        {
            return db.TipoEndereco.ToList();
        }

        // GET: TipoEnderecoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEndereco tipoEndereco = db.TipoEndereco.Find(id);
            if (tipoEndereco == null)
            {
                return HttpNotFound();
            }
            return View(tipoEndereco);
        }

        // GET: TipoEnderecoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEnderecoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoEnderecoID,Nome,rowguid,DataModificacao")] TipoEndereco tipoEndereco)
        {
            if (ModelState.IsValid)
            {
                db.TipoEndereco.Add(tipoEndereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEndereco);
        }

        // GET: TipoEnderecoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEndereco tipoEndereco = db.TipoEndereco.Find(id);
            if (tipoEndereco == null)
            {
                return HttpNotFound();
            }
            return View(tipoEndereco);
        }

        // POST: TipoEnderecoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoEnderecoID,Nome,rowguid,DataModificacao")] TipoEndereco tipoEndereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEndereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEndereco);
        }

        // GET: TipoEnderecoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEndereco tipoEndereco = db.TipoEndereco.Find(id);
            if (tipoEndereco == null)
            {
                return HttpNotFound();
            }
            return View(tipoEndereco);
        }

        // POST: TipoEnderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEndereco tipoEndereco = db.TipoEndereco.Find(id);
            db.TipoEndereco.Remove(tipoEndereco);
            db.SaveChanges();
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
