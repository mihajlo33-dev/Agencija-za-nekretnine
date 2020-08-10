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
    public class kucasController : Controller
    {
        private agencijaEntities db = new agencijaEntities();

        // GET: kucas
        public ActionResult Index()
        {
            var kucas = db.kucas.Include(k => k.agencija);
            return View(kucas.ToList());
        }

        // GET: kucas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kuca kuca = db.kucas.Find(id);
            if (kuca == null)
            {
                return HttpNotFound();
            }
            return View(kuca);
        }

        // GET: kucas/Create
        public ActionResult Create()
        {
            ViewBag.ID_agencija = new SelectList(db.agencijas, "ID_agencija", "ime_agencije");
            return View();
        }

        // POST: kucas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_kuca,zemljiste,kvadratura,bazen,adresa,ID_agencija")] kuca kuca)
        {
            if (ModelState.IsValid)
            {
                db.kucas.Add(kuca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_agencija = new SelectList(db.agencijas, "ID_agencija", "ime_agencije", kuca.ID_agencija);
            return View(kuca);
        }

        // GET: kucas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kuca kuca = db.kucas.Find(id);
            if (kuca == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_agencija = new SelectList(db.agencijas, "ID_agencija", "ime_agencije", kuca.ID_agencija);
            return View(kuca);
        }

        // POST: kucas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_kuca,zemljiste,kvadratura,bazen,adresa,ID_agencija")] kuca kuca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kuca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_agencija = new SelectList(db.agencijas, "ID_agencija", "ime_agencije", kuca.ID_agencija);
            return View(kuca);
        }

        // GET: kucas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kuca kuca = db.kucas.Find(id);
            if (kuca == null)
            {
                return HttpNotFound();
            }
            return View(kuca);
        }

        // POST: kucas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kuca kuca = db.kucas.Find(id);
            db.kucas.Remove(kuca);
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
