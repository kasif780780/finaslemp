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
    public class PayrollsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payrolls
        public async Task<ActionResult> Index()
        {
            var payrolls = db.Payrolls.Include(p => p.Employee);
            return View(await payrolls.ToListAsync());
        }

        // GET: Payrolls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payroll payroll = await db.Payrolls.FindAsync(id);
            if (payroll == null)
            {
                return HttpNotFound();
            }
            return View(payroll);
        }

        // GET: Payrolls/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name");
            return View();
        }

        // POST: Payrolls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PayrollID,EmployeeNumber,PayrollDate,Amount,PaymentType,IsPFContribution,PFNumber,IsESIContribution,EsiNumber,EmployeeID,HRT,MCA,Incentive,IncomeTax,PF")] Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                db.Payrolls.Add(payroll);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", payroll.EmployeeID);
            return View(payroll);
        }

        // GET: Payrolls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payroll payroll = await db.Payrolls.FindAsync(id);
            if (payroll == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", payroll.EmployeeID);
            return View(payroll);
        }

        // POST: Payrolls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PayrollID,EmployeeNumber,PayrollDate,Amount,PaymentType,IsPFContribution,PFNumber,IsESIContribution,EsiNumber,EmployeeID,HRT,MCA,Incentive,IncomeTax,PF")] Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payroll).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", payroll.EmployeeID);
            return View(payroll);
        }

        // GET: Payrolls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payroll payroll = await db.Payrolls.FindAsync(id);
            if (payroll == null)
            {
                return HttpNotFound();
            }
            return View(payroll);
        }

        // POST: Payrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Payroll payroll = await db.Payrolls.FindAsync(id);
            db.Payrolls.Remove(payroll);
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
