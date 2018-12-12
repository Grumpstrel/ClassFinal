using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalApp
{    
    public enum RentalLocations
    {
        Seattle,
        Dallas,
        Denver,
        WashingtonDC
    }

    public enum VehicleRentalClassification
    {
        Luxary,
        Premium,
        Standard,
        Economy,
        Subcompact
    }

    public class RentalAgreement
    {
        public static RentalModel db = new RentalModel();

        public int RentalID { get; set; }
        #region Properties
        public string ReservationEmail { get; set; }
        public DateTime DateOfPickup { get; set; }
        public RentalLocations LocationToPickup { get; set; }
        public DateTime DateOfReturn { get; set; }
        public RentalLocations LocationToDropOff { get; set; }
        public string Destination { get; set; }
        public string Drivers { get; set; }


        #endregion

        public static void Reservation(DateTime dateOfPickup, RentalLocations locationToPickup, DateTime dateOfReturn, RentalLocations locationToDropOff, string destination, string drivers,string email)
        {

            var reservation = new RentalAgreement
            {
                ReservationEmail = email,
                DateOfPickup = dateOfPickup,
                LocationToPickup = locationToPickup,
                DateOfReturn = dateOfReturn,
                LocationToDropOff = locationToDropOff,
                Destination = destination,
                Drivers = drivers,
            };

            db.Reservervation.Add(reservation);
            db.SaveChanges();
            
        }
        public static IEnumerable<RentalAgreement> GetAllReservations()
        {
            return db.Reservervation;
        }

        public static IEnumerable<RentalAgreement> GetMyRentalAgreements(string customerEmailAddress)
        {
            return db.Reservervation.Where(r => r.ReservationEmail == customerEmailAddress);
        }
    }
}
