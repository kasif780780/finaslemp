using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmpManager.Entities;
using EmpManager.Models;
using PagedList;

namespace EmpManager.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)

        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var employees = from s in db.Employees
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.Contains(searchString)
                                       || s.Address.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    employees = employees.OrderBy(s => s.Address);
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(s => s.DateofJoin);
                    break;
                default:  // Name ascending 
                    employees = employees.OrderBy(s => s.Email);
                    break;
            }

            int pageSize = 1;
            int pageNumber = (page ?? 1);
            employees = db.Employees.Include(e => e.Department).Include(e => e.Designation);
            return View(employees.OrderBy(p=>p.Name).ToPagedList(pageNumber, pageSize));
            //var employees = from s in db.Employees
            //                select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    employees = employees.Where(s => s.Name.Contains(searchString)
            //                           || s.Email.Contains(searchString));
            //}
            // employees = db.Employees.Include(e => e.Department).Include(e => e.Designation);
            //return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name");
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee, HttpPostedFileBase file,HttpPostedFileBase file1)
        {

            string path = null;
            string path1 = null;



            if (ModelState.IsValid )
                {
                  

                if (file != null && file1!=null)

                    {
                    string name = Path.GetFileName(file.FileName);
                    string name1 = Path.GetFileName(file1.FileName);

                    path = "~/Images/" + name;
                    path1 = "~/UploadFiles/" + name1;
                    file.SaveAs(Server.MapPath(path));
                    file1.SaveAs(Server.MapPath(path1));

                }
                    db.Employees.Add(new Employee
                    {
                        EmployeeID = employee.EmployeeID,
                        Name = employee.Name,
                        DateofJoin = employee.DateofJoin,
                        Phone = employee.Phone,
                        Email = employee.Email,
                        Birthday = employee.Birthday,
                        Address = employee.Address,
                        Gender = employee.Gender,
                        PassportExpairyDate = employee.PassportExpairyDate,
                        PassportNo = employee.PassportNo,
                        Nationality = employee.Nationality,
                        RelationShip = employee.RelationShip,
                        Religion = employee.Religion,
                        MartialStatus = employee.MartialStatus,
                        NofChildren = employee.NofChildren,
                        PrimaryName = employee.PrimaryName,
                        PrimaryPhone = employee.PrimaryPhone,
                        DepartmentID = employee.DepartmentID,
                        DesignationID = employee.DesignationID,
                        Password = employee.Password,
                        ConfirmPassword= employee.ConfirmPassword,
                        UserRoles =employee.UserRoles,

                         


                        EmployeePhoto = path,
                        Resume = path1
                    });
                    TempData["message"] = string.Format("added new photo");
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    db.Employees.Add(new Employee
                    {
                        EmployeeID = employee.EmployeeID,
                        Name = employee.Name,
                        DateofJoin = employee.DateofJoin,
                        Phone = employee.Phone,
                        Email = employee.Email,
                        Birthday = employee.Birthday,
                        Address = employee.Address,
                        Gender = employee.Gender,
                        PassportExpairyDate = employee.PassportExpairyDate,
                        PassportNo = employee.PassportNo,
                        Nationality = employee.Nationality,
                        RelationShip = employee.RelationShip,
                        Religion = employee.Religion,
                        MartialStatus = employee.MartialStatus,
                        NofChildren = employee.NofChildren,
                        PrimaryName = employee.PrimaryName,
                        PrimaryPhone = employee.PrimaryPhone,
                        DepartmentID = employee.DepartmentID,
                        DesignationID = employee.DesignationID,
                        Password = employee.Password,
                        ConfirmPassword = employee.ConfirmPassword,
                        UserRoles = employee.UserRoles


                    });
                }
            


            

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", employee.DepartmentID);
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "Name", employee.DesignationID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id, HttpPostedFileBase file, HttpPostedFileBase file1)
        
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", employee.DepartmentID);
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "Name", employee.DesignationID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee, HttpPostedFileBase file)
        {
            string path = null;
            string path1 = null;

            if (ModelState.IsValid)
            {
               
                if (file != null )

                {
                    string name = Path.GetFileName(file.FileName);
                   

                    path = "~/Images/" + name;
           
                    employee.EmployeePhoto = path;
                    employee.Resume = path1;
                    file.SaveAs(Server.MapPath(path));
                  

                   

                }
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", employee.DepartmentID);
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "Name", employee.DesignationID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult DeleteEmp(int id)
        {
            bool result = false;
            var u = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            if (u != null)
            {
                db.Employees.Remove(u);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult FileUpload()
        {
            return View();
        }
        [HttpPost]
        [ActionName("FileUpload")]
        public JsonResult Index_Post(Employee employee, HttpPostedFileBase file)
        {
            bool flag = true;
            string responseMessage = string.Empty;

            if (Request.Files.Count > 0)
            {
                file = Request.Files[0];

                //add more conditions like file type, file size etc as per your need.
                if (file != null && file.ContentLength > 0 && (Path.GetExtension(file.FileName).ToLower() == ".pdf" || Path.GetExtension(file.FileName).ToLower() == ".xls"))
                {
                    try
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        string filePath = Path.Combine(Server.MapPath("~/UploadFiles"), fileName);
                        file.SaveAs(filePath);
                        db.Employees.Add(new Employee
                        {
                            EmployeeID = employee.EmployeeID,
                            EmployeePhoto = filePath
                        });
                        TempData["message"] = string.Format("added new photo");
                        
                        flag = true;
                        db.SaveChanges();
                        responseMessage = "Upload Successful.";
                    }
                    catch (Exception ex)
                    {
                        flag = false;
                        responseMessage = "Upload Failed with error: " + ex.Message;
                    }
                }
                else
                {
                    flag = false;
                    responseMessage = "File is invalid.";
                }
            }
            else
            {
                flag = false;
                responseMessage = "File Upload has no file.";
            }

            return Json(new { success = flag, responseMessage = responseMessage }, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Bill(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return new Rotativa.MVC.ViewAsPdf()
            {

                FileName = "test"


            };
        }

    }
}
