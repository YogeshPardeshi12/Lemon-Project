using Lemon_Task.Models;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Net;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lemon_Task.Controllers
{
    public class FruitController : Controller
    {
        public Yogesh_Entity db = new Yogesh_Entity();
        // GET: Fruit
        public ActionResult Index()
        {
             var fruits_tbl = db.Fruits_Table.Include(f=>f.Veg_id);
            return View(fruits_tbl.ToList());
        }
        [HttpGet]
        public ActionResult Details()
        {
            var items = db.Fruits_Table.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }

            return View("Index");
        }
        public ActionResult Create()
        {
            ViewBag.veg_Id = new SelectList(db.Vegetables_Table, "veg_Id", "veg_Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fruit_id,Fruit_name,veg_Id")] Fruits_Table fruits_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Fruits_Table.Add(fruits_tbl);
                db.SaveChanges();
                TempData["message"] = "Your Data Save Successfuly..";


                return RedirectToAction("Index");

            }

            ViewBag.veg_Id = new SelectList(db.Vegetables_Table, "veg_Id", "veg_Name", fruits_tbl.Veg_id);
            return View(fruits_tbl);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fruits_Table fruits_tbl = db.Fruits_Table.Find(id);
            if (fruits_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.veg_Id = new SelectList(db.Vegetables_Table, "veg_Id", "veg_Name", fruits_tbl.Veg_id);
            return View(fruits_tbl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fruit_id,Fruit_name,veg_Id")] Fruits_Table fruits_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fruits_tbl).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "Your Data Update Successfuly";

                return RedirectToAction("Index");
            }
            ViewBag.veg_Id = new SelectList(db.Vegetables_Table, "veg_Id", "veg_Name", fruits_tbl.Veg_id);
            return View(fruits_tbl);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fruits_Table fruits_tbl = db.Fruits_Table.Find(id);
            if (fruits_tbl == null)
            {
                return HttpNotFound();
            }
            return View(fruits_tbl);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fruits_Table fruits_tbl = db.Fruits_Table.Find(id);
            db.Fruits_Table.Remove(fruits_tbl);
            db.Entry(fruits_tbl).State = EntityState.Deleted;
            TempData["Delete"] = "Data Delete Sucessfully!";


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