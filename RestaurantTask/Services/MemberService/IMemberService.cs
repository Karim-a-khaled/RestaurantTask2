using RestaurantTask.Models.DTOS;
using RestaurantTask.Models;

namespace RestaurantTask.Services.MemberService
{
    public interface IMemberService
    {
        List<AppUser> GetAllMembers();
        AppUser GetSingleMember(string id);
        AppUser UpdateMember(AppUser request);
        AppUser DeleteMember(string id);
    }
}
