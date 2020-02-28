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
    public class IncomesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Incomes
        public async Task<ActionResult> Index()
        {
            return View(await db.Incomes.ToListAsync());
        }

        // GET: Incomes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = await db.Incomes.FindAsync(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // GET: Incomes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Incomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IncomeID,Date,Amount")] Income income)
        {
            if (ModelState.IsValid)
            {
                db.Incomes.Add(income);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(income);
        }

        // GET: Incomes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = await db.Incomes.FindAsync(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // POST: Incomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IncomeID,Date,Amount")] Income income)
        {
            if (ModelState.IsValid)
            {
                db.Entry(income).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(income);
        }

        // GET: Incomes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = await db.Incomes.FindAsync(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Income income = await db.Incomes.FindAsync(id);
            db.Incomes.Remove(income);
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
