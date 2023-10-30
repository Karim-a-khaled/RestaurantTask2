using AutoMapper;
using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;

namespace RestaurantTask.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationDto>();
            // Add more mappings for other classes if needed
        }
    }
}