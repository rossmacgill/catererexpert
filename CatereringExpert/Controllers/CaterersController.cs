using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CatereringExpert.Models;
using System.IO;
using PagedList;

namespace CatereringExpert.Controllers
{
    public class CaterersController : Controller
    {
        private CatererDBContext db = new CatererDBContext();

        // GET: Caterers
        //public ActionResult Index()
        //{
        //    return View(db.Caterers.ToList());
        //}

        public ActionResult Index(string foodGenre, string searchString, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EventSortParm = sortOrder == "Event" ? "event_desc" : "Event";
            ViewBag.FoodSortParm = sortOrder == "Food" ? "food_desc" : "Food";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var GenreLst = new List<string>();

            var GenreQry = from d in db.Caterers
                           orderby d.Foodtype
                           select d.Foodtype;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.foodGenre = new SelectList(GenreLst);

            var Caterers = from m in db.Caterers
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Caterers = Caterers.Where(s => s.CompanyName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(foodGenre))
            {
                Caterers = Caterers.Where(x => x.Foodtype == foodGenre);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Caterers = Caterers.OrderByDescending(m => m.CompanyName);
                    break;
                case "event_desc":
                    Caterers = Caterers.OrderBy(m => m.EventType);
                    break;
                case "food_desc":
                    Caterers = Caterers.OrderByDescending(m => m.Foodtype);
                    break;
                case "price_desc":
                    Caterers = Caterers.OrderByDescending(m => m.AvePrice);
                    break;
                default:
                    Caterers = Caterers.OrderBy(m => m.CompanyName);
                    break;

            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Caterers.ToPagedList(pageNumber, pageSize));


        }

        [ChildActionOnly]
        public ActionResult ChildAction(string param)
        {
            ViewBag.Message = "Child Action called. " + param;
            return View();
        }  

        // GET: Caterers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caterers caterers = db.Caterers.Find(id);
            if (caterers == null)
            {
                return HttpNotFound();
            }
            return View(caterers);
        }

        // GET: Caterers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caterers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,Address,City,Postcode,PhoneNumber,EventType,Foodtype,AvePrice,Description,Website,Email,Photo")] HttpPostedFileBase imageLoad2, Caterers caterers)
        {

            if (ModelState.IsValid)
            {

                db.Caterers.Add(caterers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caterers);
        }

        // GET: Caterers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caterers caterers = db.Caterers.Find(id);
            if (caterers == null)
            {
                return HttpNotFound();
            }
            return View(caterers);
        }

        // POST: Caterers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,Address,City,Postcode,PhoneNumber,EventType,Foodtype,AvePrice,Description,Website,Email")] Caterers caterers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caterers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caterers);
        }

        // GET: Caterers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caterers caterers = db.Caterers.Find(id);
            if (caterers == null)
            {
                return HttpNotFound();
            }
            return View(caterers);
        }



        // POST: Caterers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caterers caterers = db.Caterers.Find(id);
            db.Caterers.Remove(caterers);
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
