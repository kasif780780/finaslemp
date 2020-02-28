﻿using System;
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
    public class LeaveTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LeaveTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.LeaveTypes.ToListAsync());
        }

        // GET: LeaveTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveType leaveType = await db.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return HttpNotFound();
            }
            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LeaveTypeID,Type,Day")] LeaveType leaveType)
        {
            if (ModelState.IsValid)
            {
                db.LeaveTypes.Add(leaveType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(leaveType);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveType leaveType = await db.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return HttpNotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LeaveTypeID,Type,Day")] LeaveType leaveType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(leaveType);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveType leaveType = await db.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return HttpNotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LeaveType leaveType = await db.LeaveTypes.FindAsync(id);
            db.LeaveTypes.Remove(leaveType);
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
