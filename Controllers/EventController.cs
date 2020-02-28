using EmpManager.Entities;
using EmpManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpManager.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        // GET: Event
        public ActionResult Index()
        {
            return PartialView("_EventPagePartial");
        }
        public ActionResult GetEvents()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var events = db.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
        }
        [HttpPost]
        public JsonResult SaveEvent(Event e)
        {
            var status = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (e.EventID > 0)
                {
                    //Update the Event
                    var v = db.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    db.Events.Add(e);

                }
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var v = db.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {

                    db.Events.Remove(v);
                    db.SaveChanges();
                    status = true;

                }
            }
            return new JsonResult { Data = new { status = status } };

        }
    }
}