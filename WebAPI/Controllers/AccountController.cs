using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Dtos;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork uow;

        public AccountController(IUnitOfWork uow)
        {
            this.uow = uow;

        }

        //api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var user = await uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var loginResDto = new LoginResDto {
                UserName = user.Username,
                Token = "JWT Token, yet to be created and retrieved"
            };

            return Ok(loginResDto);
        }

    }
}