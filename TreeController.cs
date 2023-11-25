using Lemon_Maschine_Test.Data_Access_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lemon_Maschine_Test.Controllers
{
    public class TreeController : Controller
    {
        
        public DB_AnkitEntities db = new DB_AnkitEntities();
        // GET: Tree
        public ActionResult TreeView()
        {
            ViewBag.NodeTable = NodeDropdownlist();

            return View();
        }
        public ActionResult NodePartialView()
        {
            ViewBag.NodeTable = NodeDropdownlist();
            return View();
        }
       

        public ActionResult ReportNodes()
        {
            using(DB_AnkitEntities db = new DB_AnkitEntities())
            return View(db);
        }
        public ActionResult SaveOrUpdate(NodeTable node)
        {
            try
            {
                using (DB_AnkitEntities db = new DB_AnkitEntities())
                {
                    if (node.NodeId == 0)
                    {
                        NodeTable table = new NodeTable()
                        {
                            NodeId = node.NodeId,
                            NodeName = node.NodeName,
                            ParentNodeId = node.ParentNodeId,
                            IsActive = node.IsActive,
                            StartDate = node.StartDate
                        };
                        db.Entry(table).State = System.Data.Entity.EntityState.Added;
                    }
                    else
                    {
                        NodeTable table = new NodeTable()
                        {
                            NodeId = node.NodeId,
                            NodeName = node.NodeName,
                            ParentNodeId = node.ParentNodeId,
                            IsActive = node.IsActive,
                            StartDate = node.StartDate
                        };
                        db.Entry(table).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("NodePartialView");
            }

        public ActionResult Detail(int id)
        {
            using (DB_AnkitEntities db = new DB_AnkitEntities())
            {
                var getdetail = db.NodeTables.Find(id);
                return View();
            }
        }
        public ActionResult EditData(int id)
        {

            using (DB_AnkitEntities db = new DB_AnkitEntities())
            {
                var data = new NodeTable();
                data = db.NodeTables.Where(x => x.NodeId == id).FirstOrDefault();
                NodeTable table = new NodeTable()
                {
                    NodeId = data.NodeId,
                    NodeName = data.NodeName,
                    ParentNodeId = data.ParentNodeId,
                    IsActive = data.IsActive,
                    StartDate = data.StartDate
                };
                return RedirectToAction("NodePartialView");
            }
        }

        public  List <SelectListItem> NodeDropdownlist()
        {
            var itemlist = new List<SelectListItem>();
            itemlist.Add(new SelectListItem { Value = "0", Text = "---select---" });
            try
            {
                using (DB_AnkitEntities db = new DB_AnkitEntities())
                {
                    var item = (from m in db.NodeTables
                                select new { m.NodeId, m.NodeName }).ToList();
                    foreach (var data in item )
                    {
                        //itemlist.Add(new SelectListItem { Value = data.NodeId.ToString(), Text = data.NodeName.ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return itemlist;

        }

    }
}
