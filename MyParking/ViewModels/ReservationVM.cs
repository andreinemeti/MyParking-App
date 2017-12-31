using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MyParking.Models;

namespace MyParking.ViewModels
{
    public class ReservationVM
    {
        [Key]
        public int ReservationID { get; set; }

        [DisplayName("Name")]
        public int CustomerID { get; set; }

        [DisplayName("Parking Lot")]
        public int ParkingID { get; set; }

        [Required]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }


        public virtual CustomerVM Customer { get; set; }
        public virtual ParkingLotVM ParkingLot { get; set; }

        public static ReservationVM MapTo(Reservation reservation)
        {
            return new ReservationVM
            {
                ReservationID = reservation.ReservationID,
                CustomerID = reservation.CustomerID,
                ParkingID = reservation.ParkingID,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,

                Customer = CustomerVM.MapTo(reservation.Customer),
                ParkingLot = ParkingLotVM.MapTo(reservation.ParkingLot)
            };
        }

        public static Reservation MapTo(ReservationVM reservationVM)
        {
            return new Reservation
            {
                ReservationID = reservationVM.ReservationID,
                CustomerID = reservationVM.CustomerID,
                ParkingID = reservationVM.ParkingID,
                StartDate = reservationVM.StartDate,
                EndDate = reservationVM.EndDate,

                Customer = CustomerVM.MapTo(reservationVM.Customer),
                ParkingLot = ParkingLotVM.MapTo(reservationVM.ParkingLot)
            };
        }
    }
}