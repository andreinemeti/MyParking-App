using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyParking.Models;
using MyParking.ViewModels;
using System;
using PagedList;
using PagedList.Mvc;

namespace MyParking.Controllers
{
    public class CustomersController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            var customersVM = new List<CustomerVM>();

            foreach (var customer in customers)
            {
                customersVM.Add(CustomerVM.MapTo(customer));
            }


            return View(customersVM);
        }

        // GET: Customers/Details/5
        [Route("customers/details/")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var customerVM = CustomerVM.MapTo(customer);
            return View(customerVM);
        }

        // GET: Customers/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Phone")] CustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                var customer = CustomerVM.MapTo(customerVM);
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerVM);
        }

        // GET: Customers/Edit/5
        [Authorize]
        [Route("customers/edit/")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var customersVM = CustomerVM.MapTo(customer);
            return View(customersVM);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("customers/edit/")]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var customersVM = CustomerVM.MapTo(customer);
            return View(customersVM);


        }

        // GET: Customers/Delete/5
        [Authorize]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var customersVM = CustomerVM.MapTo(customer);
            return View(customersVM);
        }

        // POST: Customers/Delete/5

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);


            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                TempData["Error"] = "Delete reservation first!";
            }

            return RedirectToAction("ReservationException");
        }


        public ActionResult DeleteSelected(string[] ids)
        {
            int[] id = null;
            if (ids != null)
            {
                id = new int[ids.Length];
                int j = 0;
                foreach (string i in ids)
                {
                    int.TryParse(i, out id[j++]);
                }
            }

            if (id != null && id.Length > 0)
            {
                List<Customer> allSelected = new List<Customer>();
                using (Entities2 dc = new Entities2())
                {
                    allSelected = dc.Customers.Where(c => id.Contains(c.CustomerID)).ToList();
                    foreach (var i in allSelected)
                    {
                        dc.Customers.Remove(i);
                    }

                    try
                    {
                        dc.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        TempData["Error"] = "Delete reservation first!";
                    }

                    return RedirectToAction("ReservationException");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult ReservationException()
        {
            return View();
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
