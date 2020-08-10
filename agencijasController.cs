using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication111.Models;

namespace WebApplication111.Controllers
{
    public class agencijasController : Controller
    {
        private agencijaEntities db = new agencijaEntities();

        // GET: agencijas
        public ActionResult Index()
        {
            return View(db.agencijas.ToList());
        }

        // GET: agencijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agencija agencija = db.agencijas.Find(id);
            if (agencija == null)
            {
                return HttpNotFound();
            }
            return View(agencija);
        }

        // GET: agencijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: agencijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_agencija,ime_agencije,kontakt_telefon,e_mail,web_sajt,adresa")] agencija agencija)
        {
            if (ModelState.IsValid)
            {
                db.agencijas.Add(agencija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agencija);
        }

        // GET: agencijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agencija agencija = db.agencijas.Find(id);
            if (agencija == null)
            {
                return HttpNotFound();
            }
            return View(agencija);
        }

        // POST: agencijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_agencija,ime_agencije,kontakt_telefon,e_mail,web_sajt,adresa")] agencija agencija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agencija);
        }

        // GET: agencijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agencija agencija = db.agencijas.Find(id);
            if (agencija == null)
            {
                return HttpNotFound();
            }
            return View(agencija);
        }

        // POST: agencijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            agencija agencija = db.agencijas.Find(id);
            db.agencijas.Remove(agencija);
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
