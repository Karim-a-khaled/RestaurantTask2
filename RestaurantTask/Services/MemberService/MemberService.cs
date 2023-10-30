using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantTask.Data;
using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;

namespace RestaurantTask.Services.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly DataContext _context;
        public MemberService(DataContext context)
        {
            _context = context;
        }
        public AppUser DeleteMember(string id)
        {
            var member = _context.Users.Find(id);
            _context.Users.Remove(member);
            _context.SaveChanges();
            return member;
        }

        public List<AppUser> GetAllMembers()
        {
            var members = _context.Users.ToList();
            return members;
        }

        public AppUser GetSingleMember(string id)
        {
            var member = _context.Users.Find(id);
            return member;
        }

        public AppUser UpdateMember(AppUser request)
        {
            _context.Users.Update(request);
            _context.SaveChanges();
            return request;
        }
    }
}
