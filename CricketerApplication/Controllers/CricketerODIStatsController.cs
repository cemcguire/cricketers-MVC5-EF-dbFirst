using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CricketerApplication.Models;

namespace CricketerApplication.Controllers
{
    public class CricketerODIStatsController : Controller
    {
        private MyCricketerEntities db = new MyCricketerEntities();

        // GET: /CricketerODIStats/
        public ActionResult Index()
        {
            var cricketer_odi_statistics = db.Cricketer_ODI_Statistics.Include(c => c.Cricketer);
            return View(cricketer_odi_statistics.ToList());
        }

        // GET: /CricketerODIStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_ODI_Statistics cricketer_odi_statistics = db.Cricketer_ODI_Statistics.Find(id);
            if (cricketer_odi_statistics == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_odi_statistics);
        }

        // GET: /CricketerODIStats/Create
        public ActionResult Create()
        {
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name");
            return View();
        }

        // POST: /CricketerODIStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ODI_ID,Cricketer_ID,Name,Half_Century,Century")] Cricketer_ODI_Statistics cricketer_odi_statistics)
        {
            if (ModelState.IsValid)
            {
                db.Cricketer_ODI_Statistics.Add(cricketer_odi_statistics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_odi_statistics.Cricketer_ID);
            return View(cricketer_odi_statistics);
        }

        // GET: /CricketerODIStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_ODI_Statistics cricketer_odi_statistics = db.Cricketer_ODI_Statistics.Find(id);
            if (cricketer_odi_statistics == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_odi_statistics.Cricketer_ID);
            return View(cricketer_odi_statistics);
        }

        // POST: /CricketerODIStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ODI_ID,Cricketer_ID,Name,Half_Century,Century")] Cricketer_ODI_Statistics cricketer_odi_statistics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cricketer_odi_statistics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_odi_statistics.Cricketer_ID);
            return View(cricketer_odi_statistics);
        }

        // GET: /CricketerODIStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_ODI_Statistics cricketer_odi_statistics = db.Cricketer_ODI_Statistics.Find(id);
            if (cricketer_odi_statistics == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_odi_statistics);
        }

        // POST: /CricketerODIStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cricketer_ODI_Statistics cricketer_odi_statistics = db.Cricketer_ODI_Statistics.Find(id);
            db.Cricketer_ODI_Statistics.Remove(cricketer_odi_statistics);
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
