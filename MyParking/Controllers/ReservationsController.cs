using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyParking.Models;
using MyParking.ViewModels;

namespace MyParking.Controllers
{
    public class ReservationsController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: Reservations
        public ActionResult Index()
        {

            // get list of reservations from db
            var reservations = db.Reservations.Include(r => r.Customer).Include(r => r.ParkingLot).ToList();

            // create list of reservations from ViewModel

            var reservationsVM = new List<ReservationVM>();

            foreach (var reservation in reservations)
            {
                reservationsVM.Add(ReservationVM.MapTo(reservation));
            }

            return View(reservationsVM);
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            var reservationsVM = ReservationVM.MapTo(reservation);
            return View(reservationsVM);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.ParkingID = new SelectList(db.ParkingLots.GroupBy(x => x.ParkingName).Select(x => x.FirstOrDefault()).ToList(), "ParkingID", "ParkingName");
            
            //ViewBag.CustomerID = new SelectList(db.ParkingLots, "ParkingID", "ParkingName");
            return View();
        }



        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationID,CustomerID,ParkingID,StartDate,EndDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", reservation.CustomerID);
            ViewBag.ParkingID = new SelectList(db.ParkingLots.GroupBy(x => x.ParkingName).Select(x => x.FirstOrDefault()).ToList(), "ParkingID", "ParkingName");
            var reservationsVM = ReservationVM.MapTo(reservation);
            return View(reservationsVM);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", reservation.CustomerID);
            ViewBag.ParkingID = new SelectList(db.ParkingLots.GroupBy(x => x.ParkingName).Select(x => x.FirstOrDefault()).ToList(), "ParkingID", "ParkingName");
            var reservationsVM = ReservationVM.MapTo(reservation);
            return View(reservationsVM);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationID,CustomerID,ParkingID,StartDate,EndDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", reservation.CustomerID);
            ViewBag.ParkingID = new SelectList(db.ParkingLots.GroupBy(x => x.ParkingName).Select(x => x.FirstOrDefault()).ToList(), "ParkingID", "ParkingName");

            var reservationsVM = ReservationVM.MapTo(reservation);
            return View(reservationsVM);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            var reservationsVM = ReservationVM.MapTo(reservation);
            
            return View(reservationsVM);
        }

        // POST: Reservations/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
