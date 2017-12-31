using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyParking.Models;
using System.Data.Entity;

namespace MyParking.ViewModels
{
    public class ParkingLotVM
    {
        public ParkingLotVM()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        public virtual ICollection<Reservation> Reservations { get; set; }

        [Key]
        public int ParkingID { get; set; }

        [DisplayName("Parking Lot")]
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string ParkingName { get; set; }

        [DisplayName("Capacity")]
        [Required(ErrorMessage = "Number required!")]
        public int? Capacity { get; set; }

        [Display(Name = "Street")]
        [Required]
        public Zones? Zone { get; set; }


        public static ParkingLotVM MapTo(ParkingLot parkingLot)
        {
            return new ParkingLotVM
            {
                ParkingID = parkingLot.ParkingID,
                ParkingName = parkingLot.ParkingName,
                Capacity = parkingLot.Capacity,
                Zone = (Zones?)parkingLot.Zone
            };
        }

        public static ParkingLot MapTo(ParkingLotVM parkingLotVM)
        {
            return new ParkingLot
            {
                ParkingID = parkingLotVM.ParkingID,
                ParkingName = parkingLotVM.ParkingName,
                Capacity = parkingLotVM.Capacity,
                Zone = (int?)parkingLotVM.Zone
            };
        }

    }
}