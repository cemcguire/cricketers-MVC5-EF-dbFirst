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
    public class CricketerTestStatsController : Controller
    {
        private MyCricketerEntities db = new MyCricketerEntities();

        // GET: /CricketerTestStats/
        public ActionResult Index()
        {
            var cricketer_test_statistics = db.Cricketer_Test_Statistics.Include(c => c.Cricketer);
            return View(cricketer_test_statistics.ToList());
        }

        // GET: /CricketerTestStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Test_Statistics cricketer_test_statistics = db.Cricketer_Test_Statistics.Find(id);
            if (cricketer_test_statistics == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_test_statistics);
        }

        // GET: /CricketerTestStats/Create
        public ActionResult Create()
        {
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name");
            return View();
        }

        // POST: /CricketerTestStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Test_ID,Cricketer_ID,Name,Half_Century,Century")] Cricketer_Test_Statistics cricketer_test_statistics)
        {
            if (ModelState.IsValid)
            {
                db.Cricketer_Test_Statistics.Add(cricketer_test_statistics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_test_statistics.Cricketer_ID);
            return View(cricketer_test_statistics);
        }

        // GET: /CricketerTestStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Test_Statistics cricketer_test_statistics = db.Cricketer_Test_Statistics.Find(id);
            if (cricketer_test_statistics == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_test_statistics.Cricketer_ID);
            return View(cricketer_test_statistics);
        }

        // POST: /CricketerTestStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Test_ID,Cricketer_ID,Name,Half_Century,Century")] Cricketer_Test_Statistics cricketer_test_statistics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cricketer_test_statistics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_test_statistics.Cricketer_ID);
            return View(cricketer_test_statistics);
        }

        // GET: /CricketerTestStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Test_Statistics cricketer_test_statistics = db.Cricketer_Test_Statistics.Find(id);
            if (cricketer_test_statistics == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_test_statistics);
        }

        // POST: /CricketerTestStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cricketer_Test_Statistics cricketer_test_statistics = db.Cricketer_Test_Statistics.Find(id);
            db.Cricketer_Test_Statistics.Remove(cricketer_test_statistics);
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
