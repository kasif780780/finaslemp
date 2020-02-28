using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpManager.Entities;
using EmpManager.Models;

namespace EmpManager.Controllers
{
    public class TerminationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Terminations
        public async Task<ActionResult> Index()
        {
            var terminations = db.Terminations.Include(t => t.Employee);
            return View(await terminations.ToListAsync());
        }

        // GET: Terminations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termination termination = await db.Terminations.FindAsync(id);
            if (termination == null)
            {
                return HttpNotFound();
            }
            return View(termination);
        }

        // GET: Terminations/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name");
            return View();
        }

        // POST: Terminations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TerminationId,TerminationEmp,TerminationDate,Reason,NoticeDate,Department,EmployeeID")] Termination termination)
        {
            if (ModelState.IsValid)
            {
                db.Terminations.Add(termination);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", termination.EmployeeID);
            return View(termination);
        }

        // GET: Terminations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termination termination = await db.Terminations.FindAsync(id);
            if (termination == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", termination.EmployeeID);
            return View(termination);
        }

        // POST: Terminations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TerminationId,TerminationEmp,TerminationDate,Reason,NoticeDate,Department,EmployeeID")] Termination termination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termination).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", termination.EmployeeID);
            return View(termination);
        }

        // GET: Terminations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termination termination = await db.Terminations.FindAsync(id);
            if (termination == null)
            {
                return HttpNotFound();
            }
            return View(termination);
        }

        // POST: Terminations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Termination termination = await db.Terminations.FindAsync(id);
            db.Terminations.Remove(termination);
            await db.SaveChangesAsync();
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
