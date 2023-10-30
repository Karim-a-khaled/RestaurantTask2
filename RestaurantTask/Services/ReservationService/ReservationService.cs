using Microsoft.EntityFrameworkCore;
using RestaurantTask.Data;
using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;

namespace RestaurantTask.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly DataContext _context;
        public ReservationService(DataContext context)
        {
            _context = context;
        }

        public Reservation AddReservation(ReservationDto reservation)
        {
            var newReservation = new Reservation()
            {
                ReservationTime = reservation.ReservationTime,
                isCancelled = reservation.isCancelled
            };
            _context.Reservations.Add(newReservation);
            _context.SaveChanges();
            return newReservation;
        }

        public Reservation DeleteReservation(int id)
        {
            var ToDeleteReservation = _context.Reservations.Find(id);
            _context.Reservations.Remove(ToDeleteReservation);
            _context.SaveChanges();
            return ToDeleteReservation;
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations
                .Include(rt => rt.RestaurantTable)
                .Include(u => u.User)
                .ToList();
        }

        public Reservation GetSingleReservation(int id)
        {
            var reservation = _context.Reservations
                .Include(rt => rt.RestaurantTable)
                .Include(u => u.User)
                .FirstOrDefault(u => u.Id == id);

            return reservation;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public bool CancelReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation is null)
                return false;

            var currentTime = DateTime.Now;
            var cancellationTimeLimit = reservation.ReservationTime.AddHours(-2);

            if (currentTime >= cancellationTimeLimit)
                return false;

            reservation.isCancelled = true;
            _context.SaveChanges();
            return true;
        }
    }
}
