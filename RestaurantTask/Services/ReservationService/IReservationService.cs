using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;

namespace RestaurantTask.Services.ReservationService
{
    public interface IReservationService
    {
        List<Reservation> GetAllReservations();
        Reservation GetSingleReservation(int id);
        Reservation AddReservation(ReservationDto reservation);
        Reservation UpdateReservation(Reservation request);
        Reservation DeleteReservation(int id);
        bool CancelReservation(int id);

    }
}
