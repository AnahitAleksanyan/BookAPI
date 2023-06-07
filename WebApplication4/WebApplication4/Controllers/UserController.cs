using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Services.Interfaces;
using WebApplication4.statics;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("register")]
        [SwaggerResponse(statusCode: 200, type: typeof(User))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public async Task<ActionResult<MessageResponse>> Register(UserRegisterDTO userDTO)
        {
            try
            {
                return Ok(await _userService.Register(userDTO));
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse
                {
                    Messages = ex.Messages
                });
            }
        }

        [HttpPost("Login")]
        [SwaggerResponse(statusCode: 200, type: typeof(User))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public async Task<ActionResult<MessageResponse>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var currentUser = await _userService.Login(userLoginDTO);
                if (currentUser != null)
                {
                    var token = GenerateToken(currentUser);
                    return Ok(token);
                }

                return BadRequest();
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse
                {
                    Message = ex.Message
                });
            }
        }

        [HttpGet("profile")]
        [Authorize]
        public ActionResult GetProfile()
        {
            try
            {
                var userInfo = GetCurrentUserInformation();

                return Ok(userInfo);
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse
                {
                    Message = ex.Message
                });
            }
        }


        // To generate token
        private string GenerateToken(User user)
        {
            string? key = _config["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Email),
                new Claim(ClaimTypes.Role,"Admin")
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private dynamic GetCurrentUserInformation()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var welcome = "";
            switch (LanguageInfo.Language) {
                case "en":
                    welcome = "Hello";
                    break;
                case "ru":
                    welcome = "Привет";
                    break;
                case "am":
                    welcome = "Բարև";
                    break;

            }
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new 
                {
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                    Welcome = welcome
                };
            }
            return null;
        }
    }
}
