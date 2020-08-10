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
    public class stansController : Controller
    {
        private agencijaEntities db = new agencijaEntities();

        // GET: stans
        public ActionResult Index()
        {
            var stans = db.stans.Include(s => s.agencija).Include(s => s.zgrada);
            return View(stans.ToList());
        }

        // GET: stans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stan stan = db.stans.Find(id);
            if (stan == null)
            {
                return HttpNotFound();
            }
            return View(stan);
        }

        // GET: stans/Create
        public ActionResult Create()
        {
            ViewBag.ID_agencija = new SelectList(db.agencijas, "ID_agencija", "ime_agencije");
            ViewBag.ID_zgrada = new SelectList(db.zgradas, "ID_zgrada", "adresa");
            return View();
        }

        // POST: stans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_stan,broj_stana,vlasnik_stana,kupatilo,kvadratura,broj_soba,balkon,ID_zgrada,ID_agencija")] stan stan)
        {
            if (ModelState.IsValid)
            {
                db.stans.Add(stan);
                db.SaveChanges();
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_agencija = new SelectList(db.agencijas, "ID_agencija", "ime_agencije", stan.ID_agencija);
            ViewBag.ID_zgrada = new SelectList(db.zgradas, "ID_zgrada", "adresa", stan.ID_zgrada);
            return View(stan);
        }

        // GET: stans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stan stan = db.stans.Find(id);
            if (stan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_agencija = new SelectList(db.agencijas, "ID_agencija", "ime_agencije", stan.ID_agencija);
            ViewBag.ID_zgrada = new SelectList(db.zgradas, "ID_zgrada", "adresa", stan.ID_zgrada);
            return View(stan);
        }

        // POST: stans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_stan,broj_stana,vlasnik_stana,kupatilo,kvadratura,broj_soba,balkon,ID_zgrada,ID_agencija")] stan stan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_agencija = new SelectList(db.agencijas, "ID_agencija", "ime_agencije", stan.ID_agencija);
            ViewBag.ID_zgrada = new SelectList(db.zgradas, "ID_zgrada", "adresa", stan.ID_zgrada);
            return View(stan);
        }

        // GET: stans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stan stan = db.stans.Find(id);
            if (stan == null)
            {
                return HttpNotFound();
            }
            return View(stan);
        }

        // POST: stans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stan stan = db.stans.Find(id);
            db.stans.Remove(stan);
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
