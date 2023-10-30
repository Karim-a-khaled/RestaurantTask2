using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantTask.Models.DTOS;
using RestaurantTask.Models;
using RestaurantTask.Services.MemberService;

namespace RestaurantTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<AppUser>> GetAllMembers()
        {
            var members = _memberService.GetAllMembers();
            return Ok(members);
        }

        [HttpGet("GetById")]
        public ActionResult<AppUser> GetSingle(string id)
        {
            var result = _memberService.GetSingleMember(id);
            if (result is null)
                return NotFound("Member Not Found");
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<AppUser> Update(string id, MemberDto request)
        {
            var member = _memberService.GetSingleMember(id);
            if (member is null)
            {
                return NotFound("Member Not Found");
            }

            member.UserName = request.UserName;
            member.Email = request.Email;

            var result = _memberService.UpdateMember(member);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult<AppUser> Delete(string id)
        {
            var result = _memberService.DeleteMember(id);
            if (result is null)
                return NotFound("Member Not Found");

            return Ok(result);
        }
    }
}
