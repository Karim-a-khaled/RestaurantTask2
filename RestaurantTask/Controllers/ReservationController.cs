using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;
using RestaurantTask.Services.MemberService;
using RestaurantTask.Services.ReservationService;

namespace RestaurantTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, IMemberService memberService, IMapper mapper)
        {
            _reservationService = reservationService;
            _memberService = memberService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Reservation>> GetAllReservation()
        {
            var restaurants = _reservationService.GetAllReservations();
            return Ok(restaurants);
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
        public ActionResult<ReservationDto> Post(ReservationDto reservation)
        {
            var result = _reservationService.AddReservation(reservation);
            return Ok(result);
        }

        [HttpPost("AddTableType")]
        public ActionResult<ReservationDto> PostTableType(ReservationDto reservation)
        {
            var result = _reservationService.AddReservation(reservation);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<ReservationDto> Update(int id, ReservationDto reservationInput)
        {
            var reservation = _reservationService.GetSingleReservation(id);

            if (reservation is null)
            {
                return NotFound("Reservation Not Found");
            }

            reservation.ReservationTime = reservationInput.ReservationTime;
            reservation.isCancelled = reservationInput.isCancelled;


            var result = _reservationService.UpdateReservation(reservation);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult<Reservation> Delete(int id)
        {
            var result = _reservationService.DeleteReservation(id);
            if (result is null)
                return NotFound("Reservation Not Found");

            return Ok(result);
        }

        [HttpPut("{id}/Cancel")]
        public ActionResult<bool> CancelReservation(int id)
        {
            var isCancelled = _reservationService.CancelReservation(id);
            if (!isCancelled)
                return NotFound("Reservation Not Found or Cannot be Cancelled");

            return Ok("Reservation Cancelled Successfuly!");
        }

        [HttpPost("{reservationId}/users/{userId}")]
        public ActionResult<Reservation> AddReservationToUser(int reservationId, string userId)
        {
            var reservation = _reservationService.GetSingleReservation(reservationId);
            var user = _memberService.GetSingleMember(userId);
            reservation.User = user;
            _reservationService.UpdateReservation(reservation);
            var reservationToReturn= _mapper.Map<ReservationDto>(reservation);
            return Ok(reservationToReturn);
        }
    }
}
