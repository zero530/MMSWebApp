using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MMSWebApp.Models;

namespace MMSWebApp.Controllers
{
    public class MaintenanceLogDetailsController : Controller
    {
        private MaintenanceLogDetailDBContext db = new MaintenanceLogDetailDBContext();

        // GET: MaintenanceLogDetails
        public ActionResult Index(string mlSystem, string searchString)
        {
            var SystemLst = new List<string>();

            var SystemQry = from d in db.MaintenanceLogDetails

                           orderby d.System

                           select d.System;

            SystemLst.AddRange(SystemQry.Distinct());

            ViewBag.mlSystem = new SelectList(SystemLst);

            var mls = from m in db.MaintenanceLogDetails

                         select m;


            if (!string.IsNullOrEmpty(mlSystem))
            {

                mls = mls.Where(x => x.System == mlSystem);

            }

            return View(db.MaintenanceLogDetails.ToList());
        }

        // GET: MaintenanceLogDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceLogDetail maintenanceLogDetail = db.MaintenanceLogDetails.Find(id);
            if (maintenanceLogDetail == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceLogDetail);
        }

        // GET: MaintenanceLogDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceLogDetails/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,OriginID,SMEID,FunctionArea,System,SERNoTempNo,Requested_Date,Requested_By,IssueDescription,Priority,Severity,Estimated,IssueCategory,Status,ActionedBy,BaselineStart,BaselineFinish,RevisedStart,RevisedFinish,ActualStart,ActualFinish,ActualMandays,LastUpdatedDate,LastUpdatedBy,Remarks,Type,ImportDesc")] MaintenanceLogDetail maintenanceLogDetail)
        {
            if (ModelState.IsValid)
            {
                db.MaintenanceLogDetails.Add(maintenanceLogDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maintenanceLogDetail);
        }

        // GET: MaintenanceLogDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceLogDetail maintenanceLogDetail = db.MaintenanceLogDetails.Find(id);
            if (maintenanceLogDetail == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceLogDetail);
        }

        // POST: MaintenanceLogDetails/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,OriginID,SMEID,FunctionArea,System,SERNoTempNo,Requested_Date,Requested_By,IssueDescription,Priority,Severity,Estimated,IssueCategory,Status,ActionedBy,BaselineStart,BaselineFinish,RevisedStart,RevisedFinish,ActualStart,ActualFinish,ActualMandays,LastUpdatedDate,LastUpdatedBy,Remarks,Type,ImportDesc")] MaintenanceLogDetail maintenanceLogDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenanceLogDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maintenanceLogDetail);
        }

        // GET: MaintenanceLogDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceLogDetail maintenanceLogDetail = db.MaintenanceLogDetails.Find(id);
            if (maintenanceLogDetail == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceLogDetail);
        }

        // POST: MaintenanceLogDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintenanceLogDetail maintenanceLogDetail = db.MaintenanceLogDetails.Find(id);
            db.MaintenanceLogDetails.Remove(maintenanceLogDetail);
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
