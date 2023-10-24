using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;

namespace RestaurantTask.Services.ReservationService
{
    public interface IReservationService
    {
        List<Reservation> GetAllReservations();
        Reservation GetSingleReservation(int id);
        Reservation AddReservation(ReservationDto reservation);
        Reservation UpdateReservation(int id, Reservation request);
        Reservation DeleteReservation(int id);
    }
}
