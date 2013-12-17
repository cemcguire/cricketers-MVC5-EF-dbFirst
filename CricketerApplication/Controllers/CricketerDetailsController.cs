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
    public class CricketerDetailsController : Controller
    {
        private MyCricketerEntities db = new MyCricketerEntities();

        // GET: /CricketerDetails/
        public ActionResult Index()
        {
            var cricketer_details = db.Cricketer_Details.Include(c => c.Cricketer);
            return View(cricketer_details.ToList());
        }

        // GET: /CricketerDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Details cricketer_details = db.Cricketer_Details.Find(id);
            if (cricketer_details == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_details);
        }

        // GET: /CricketerDetails/Create
        public ActionResult Create()
        {
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name");
            return View();
        }

        // POST: /CricketerDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Details_ID,Cricketer_ID,Team,ODI_Runs,Test_Runs,Wickets")] Cricketer_Details cricketer_details)
        {
            if (ModelState.IsValid)
            {
                db.Cricketer_Details.Add(cricketer_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_details.Cricketer_ID);
            return View(cricketer_details);
        }

        // GET: /CricketerDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Details cricketer_details = db.Cricketer_Details.Find(id);
            if (cricketer_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_details.Cricketer_ID);
            return View(cricketer_details);
        }

        // POST: /CricketerDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Details_ID,Cricketer_ID,Team,ODI_Runs,Test_Runs,Wickets")] Cricketer_Details cricketer_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cricketer_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_details.Cricketer_ID);
            return View(cricketer_details);
        }

        // GET: /CricketerDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Details cricketer_details = db.Cricketer_Details.Find(id);
            if (cricketer_details == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_details);
        }

        // POST: /CricketerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cricketer_Details cricketer_details = db.Cricketer_Details.Find(id);
            db.Cricketer_Details.Remove(cricketer_details);
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
