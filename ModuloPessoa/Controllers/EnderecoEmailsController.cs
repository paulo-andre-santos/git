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
    public class EnderecoEmailsController : Controller
    {
        private PessoaConnection db = new PessoaConnection();

        // GET: EnderecoEmails
        public ActionResult Index()
        {
            var enderecoEmail = db.EnderecoEmail.Include(e => e.Pessoa);
            return View(enderecoEmail.ToList());
        }

        // GET: EnderecoEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEmail enderecoEmail = db.EnderecoEmail.Find(id);
            if (enderecoEmail == null)
            {
                return HttpNotFound();
            }
            return View(enderecoEmail);
        }

        // GET: EnderecoEmails/Create
        public ActionResult Create()
        {
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa");
            return View();
        }

        // POST: EnderecoEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntidadeDeNegocioID,EnderecoEmailID,Email,rowguid,DataModificacao")] EnderecoEmail enderecoEmail)
        {
            if (ModelState.IsValid)
            {
                db.EnderecoEmail.Add(enderecoEmail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", enderecoEmail.EntidadeDeNegocioID);
            return View(enderecoEmail);
        }

        // GET: EnderecoEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEmail enderecoEmail = db.EnderecoEmail.Find(id);
            if (enderecoEmail == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", enderecoEmail.EntidadeDeNegocioID);
            return View(enderecoEmail);
        }

        // POST: EnderecoEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntidadeDeNegocioID,EnderecoEmailID,Email,rowguid,DataModificacao")] EnderecoEmail enderecoEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enderecoEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntidadeDeNegocioID = new SelectList(db.Pessoa, "EntidadeDeNegocioID", "TipoPessoa", enderecoEmail.EntidadeDeNegocioID);
            return View(enderecoEmail);
        }

        // GET: EnderecoEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEmail enderecoEmail = db.EnderecoEmail.Find(id);
            if (enderecoEmail == null)
            {
                return HttpNotFound();
            }
            return View(enderecoEmail);
        }

        // POST: EnderecoEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnderecoEmail enderecoEmail = db.EnderecoEmail.Find(id);
            db.EnderecoEmail.Remove(enderecoEmail);
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
