using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_proekt.Models;

namespace IT_proekt.Controllers
{
    public class PizzaServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PizzaServices
        public ActionResult Index()
        {
            return View(db.PizzaServices.ToList());
        }

        // GET: PizzaServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaService pizzaService = db.PizzaServices.Find(id);
            if (pizzaService == null)
            {
                return HttpNotFound();
            }
            return View(pizzaService);
        }

        // GET: PizzaServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzaServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address")] PizzaService pizzaService)
        {
            if (ModelState.IsValid)
            {
                db.PizzaServices.Add(pizzaService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pizzaService);
        }

        // GET: PizzaServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaService pizzaService = db.PizzaServices.Find(id);
            if (pizzaService == null)
            {
                return HttpNotFound();
            }
            return View(pizzaService);
        }

        // POST: PizzaServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] PizzaService pizzaService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizzaService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizzaService);
        }

        // GET: PizzaServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaService pizzaService = db.PizzaServices.Find(id);
            if (pizzaService == null)
            {
                return HttpNotFound();
            }
            return View(pizzaService);
        }

        // POST: PizzaServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PizzaService pizzaService = db.PizzaServices.Find(id);
            db.PizzaServices.Remove(pizzaService);
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
