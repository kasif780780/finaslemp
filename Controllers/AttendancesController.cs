using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpManager.Entities;
using EmpManager.Models;
using Newtonsoft.Json;

namespace EmpManager.Controllers
{
    public class AttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

		public ActionResult Index()
		{

			


			return View(db.Attendances.ToList());
		}

		public ActionResult All(int? page)
		{



			List<Employee> Employees = db.Employees.ToList();

			List<Attendance> attendanceList = db.Attendances.ToList();


			List<SelectListItem> listDD = new List<SelectListItem>();

			foreach (var e in Employees)
			{
				listDD.Add(new SelectListItem
				{
					Value = e.	EmployeeID.ToString(),
					Text = e.Name 

				});

			}



			TempData["Employees"] = listDD;
			TempData["EmployeesNames"] = Employees;








			return View(attendanceList);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult All(int? Employee, int? page, string start, string end)
		{


			List<Attendance> attendanceList;




			if (Employee != null)
			{

				if (start != "" && end != "")
				{


					DateTime dtstart = Convert.ToDateTime(start);
					DateTime dtend = Convert.ToDateTime(end);

					attendanceList = db.Attendances.ToList().Where(x => x.EmployeeID == Employee && x.DateOfDay >= dtstart && dtend >= x.DateOfDay).ToList();

				}
				else
				{

					attendanceList = db.Attendances.ToList().Where(x => x.EmployeeID == Employee).ToList();
				}

				//int userID = Int32.Parse(Employee);

			}
			else if (start != "" && end != "" && Employee == null)
			{

				DateTime dtstart = Convert.ToDateTime(start);
				DateTime dtend = Convert.ToDateTime(end);
				attendanceList = db.Attendances.ToList().Where(x => x.DateOfDay >= dtstart && dtend >= x.DateOfDay).ToList();

			}
			else
			{
				attendanceList = db.Attendances.ToList();
			}

			List<Employee> Employees = db.Employees.ToList();

			List<SelectListItem> listDD = new List<SelectListItem>();
			foreach (var e in Employees)
			{
				listDD.Add(new SelectListItem
				{
					Value = e.EmployeeID.ToString(),
					Text = e.Name 

				});

			}
			TempData["Employees"] = listDD;
			TempData["EmployeesNames"] = Employees;
			TempData["Start"] = start;
			TempData["End"] = end;




			return View(attendanceList);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Attendance attendance = db.Attendances.Find(id);
			if (attendance == null)
			{
				return HttpNotFound();
			}
			return View(attendance);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Attendance attendance)
		{
			if (ModelState.IsValid)
			{
				db.Entry(attendance).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(attendance);
		}


		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Attendance Attendance = db.Attendances.Find(id);
			if (Attendance == null)
			{
				return HttpNotFound();
			}
			return View(Attendance);
		}

		// POST: Employees/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Attendance Attendance = db.Attendances.Find(id);
			db.Attendances.Remove(Attendance);
			db.SaveChanges();
			return RedirectToAction("All");
		}
	}
}
