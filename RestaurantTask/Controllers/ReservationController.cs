using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;
using RestaurantTask.Services.ReservationService;

namespace RestaurantTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Reservation>> GetAllReservation()
        {
            var restaurant = _reservationService.GetAllReservations();
            return Ok(restaurant);
        }

        [HttpGet("GetById")]
        public ActionResult<Reservation> GetSingle(int id)
        {
            var result = _reservationService.GetSingleReservation(id);
            if (result is null)
                return NotFound("Reservation Not Found");
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Reservation> Post(ReservationInput reservation)
        {
            var result = _reservationService.AddReservation(reservation);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<Reservation> Update(Reservation reservation)
        {
            var result = _reservationService.UpdateReservation(reservation.Id, reservation);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult<Reservation> Delete(int id)
        {
            var result = _reservationService.DeleteReservation(id);
            if (result == null)
                return NotFound("Reservation Not Found");

            return Ok(result);
        }
    }
}
