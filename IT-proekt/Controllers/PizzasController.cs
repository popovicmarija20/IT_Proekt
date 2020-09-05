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
    public class PizzasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pizzas
        public ActionResult Index()
        {
            return View(db.Pizzas.ToList());
        }
        public int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].pizza.Id.Equals(id))
                    return i;
            return -1;
          
        }
        public ActionResult AddToCart(int id)
        {
            
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { pizza = db.Pizzas.Find(id), Quantity = 1 });
                Session["cart"] = cart;
                ViewBag.cart = cart.Count();
                Session["count"] = 1;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                     cart[index].Quantity++;

                }
                else
                {
                    cart.Add(new Item { pizza = db.Pizzas.Find(id), Quantity = 1 });

                }
                Session["cart"] = cart;
                ViewBag.cart = cart.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            //return View("AddToCart");
            return RedirectToAction("Index");
        }
        public ActionResult MyOrder()
        {
            return View("AddToCart");
        }

        public ActionResult Payment()
        {
           
            return View("Payment");

            

        }

        public ActionResult RemoveFromCart(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            Session["count"] = cart.Count();
            return View("AddToCart");
        }

        // GET: Pizzas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // GET: Pizzas/Create

        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Create([Bind(Include = "Id,Name,Price,Image")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                db.Pizzas.Add(pizza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Edit([Bind(Include = "Id,Name,Price,Image")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizza);
        }
        [Authorize(Roles = "Admin")]

        // GET: Pizzas/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza model = db.Pizzas.Find(id);
            db.Pizzas.Remove(model);
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
