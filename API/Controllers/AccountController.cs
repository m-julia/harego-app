using API.DTO;
using API.Services;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Member> _memberManager;
        private readonly SignInManager<Member> _signInManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<Member> memberManager, SignInManager<Member> signInManager, TokenService tokenService)
        {
            _memberManager = memberManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<MemberDto>> Login(LoginDto loginDto)
        {

            var member = await _memberManager.FindByEmailAsync(loginDto.Email);
            if (member == null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(member, loginDto.Password, false);
            if (result.Succeeded)
            {
                return CreateMemberObject(member);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<MemberDto>> Register(RegisterDto registerDto)
        {
            if (await _memberManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("The Email already exists");
            }

            var member = new Member
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PhoneNumber = registerDto.PhoneNumber,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _memberManager.CreateAsync(member, registerDto.Password);

            if (result.Succeeded)
            {
                return CreateMemberObject(member);
            }

            return BadRequest("Problem registering user");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<MemberDto>> GetCurrentUser()
        {
            var t = ClaimTypes.Email;
            var email = User.FindFirstValue(t);
            var member = await _memberManager.FindByEmailAsync(email);
            return CreateMemberObject(member);
        }

        private MemberDto CreateMemberObject(Member member)
        {
            return new MemberDto
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                Birthday = member.Birthday,
                PhoneNumber = member.PhoneNumber,
                Email = member.Email,
                Token = _tokenService.CreateToken(member),
                Image = null,

            };
        }

    }
}
