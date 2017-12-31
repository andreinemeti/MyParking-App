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
    public class ParkingLotsController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: ParkingLots

        
        public ActionResult Index(int? page)
        {
            //get list of parkingLots from db
            var parkingLots = db.ParkingLots.ToList();

            //create a list of parkingLots from ViewModel
            var parkingLotsVM = new List<ParkingLotVM>();

            foreach (var parkingLot in parkingLots)
            {
                parkingLotsVM.Add(ParkingLotVM.MapTo(parkingLot));

            }
            if (User.IsInRole("CanManageParkingLots"))
            return View(parkingLotsVM);

            return RedirectToAction("ReadOnly");

        }

        public ActionResult ReadOnly()
        {
            //get list of parkingLots from db
            var parkingLots = db.ParkingLots.ToList();

            //create a list of parkingLots from ViewModel
            var parkingLotsVM = new List<ParkingLotVM>();

            foreach (var parkingLot in parkingLots)
            {
                parkingLotsVM.Add(ParkingLotVM.MapTo(parkingLot));

            }
            return View(parkingLotsVM);
        }


        // GET: ParkingLots/Details/5

        // [Authorize(Roles = "CanManageParkingLots")] - if you keep this kind of typo you'll need to change anywhere
        [Authorize(Roles = RoleName.CanManageParkingLots)] //- this way i have a class and change only once
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLot parkingLot = db.ParkingLots.Find(id);
            if (parkingLot == null)
            {
                return HttpNotFound();
            }
            var parkingLotVM = ParkingLotVM.MapTo(parkingLot);
            return View(parkingLotVM);
        }

        // GET: ParkingLots/Create

        [Authorize(Roles = RoleName.CanManageParkingLots)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkingLots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = RoleName.CanManageParkingLots)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkingID,ParkingName,Capacity, Zone")] ParkingLotVM parkingLotVM)
        {
            if (ModelState.IsValid)
            {
                var parkingLot = ParkingLotVM.MapTo(parkingLotVM);
                db.ParkingLots.Add(parkingLot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkingLotVM);
        }

        // GET: ParkingLots/Edit/5

        [Authorize(Roles = RoleName.CanManageParkingLots)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLot parkingLot = db.ParkingLots.Find(id);
            if (parkingLot == null)
            {
                return HttpNotFound();
            }
            var parkingLotsVM = ParkingLotVM.MapTo(parkingLot);
            return View(parkingLotsVM);
        }

        // POST: ParkingLots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = RoleName.CanManageParkingLots)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingID,ParkingName,Capacity,Zone")] ParkingLot parkingLot)
        {
            if (ModelState.IsValid)
            {

                db.Entry(parkingLot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var parkingLotsVM = ParkingLotVM.MapTo(parkingLot);
            return View(parkingLotsVM);
        }

        // GET: ParkingLots/Delete/5

        [Authorize(Roles = RoleName.CanManageParkingLots)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLot parkingLot = db.ParkingLots.Find(id);
            if (parkingLot == null)
            {
                return HttpNotFound();
            }
            var parkingLotsVM = ParkingLotVM.MapTo(parkingLot);
            return View(parkingLotsVM);
        }

        // POST: ParkingLots/Delete/5

        [Authorize(Roles = RoleName.CanManageParkingLots)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingLot parkingLot = db.ParkingLots.Find(id);
            db.ParkingLots.Remove(parkingLot);
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                TempData["Error"] = " You must delete reservation first!";
            }
            return RedirectToAction("ReservationException");
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
