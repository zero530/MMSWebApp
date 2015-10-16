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
    public class SMEMatrixController : Controller
    {
        private SMEMatrixDBContext db = new SMEMatrixDBContext();

        // GET: SMEMatrix
        public ActionResult Index()
        {
            return View(db.SMEMatrixs.ToList());
        }

        // GET: SMEMatrix/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMEMatrix sMEMatrix = db.SMEMatrixs.Find(id);
            if (sMEMatrix == null)
            {
                return HttpNotFound();
            }
            return View(sMEMatrix);
        }

        // GET: SMEMatrix/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMEMatrix/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FunctionArea,System,Type,APJSME1,APJSME2,APJSME3,APJSME4,MTRTeam,MTRSME1,MTRSME2,MTRSME3,MTRSME4,Remark")] SMEMatrix sMEMatrix)
        {
            if (ModelState.IsValid)
            {
                db.SMEMatrixs.Add(sMEMatrix);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sMEMatrix);
        }

        // GET: SMEMatrix/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMEMatrix sMEMatrix = db.SMEMatrixs.Find(id);
            if (sMEMatrix == null)
            {
                return HttpNotFound();
            }
            return View(sMEMatrix);
        }

        // POST: SMEMatrix/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FunctionArea,System,Type,APJSME1,APJSME2,APJSME3,APJSME4,MTRTeam,MTRSME1,MTRSME2,MTRSME3,MTRSME4,Remark")] SMEMatrix sMEMatrix)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMEMatrix).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMEMatrix);
        }

        // GET: SMEMatrix/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMEMatrix sMEMatrix = db.SMEMatrixs.Find(id);
            if (sMEMatrix == null)
            {
                return HttpNotFound();
            }
            return View(sMEMatrix);
        }

        // POST: SMEMatrix/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMEMatrix sMEMatrix = db.SMEMatrixs.Find(id);
            db.SMEMatrixs.Remove(sMEMatrix);
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
