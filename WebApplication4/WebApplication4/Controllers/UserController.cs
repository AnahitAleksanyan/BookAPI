using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [SwaggerResponse(statusCode: 200, type: typeof(User))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public async Task<ActionResult<MessageResponse>> Register(UserRegisterDTO userDTO)
        {
            try
            {
                return Ok( await _userService.Register(userDTO));

            }

            catch (CustomValidationException ex)
            {
                //ToDo Stex bdi MessageResponse@ ira mej unena nayev messages vornor stringneri list e vorpesi CustomValidationExceptioni meji stringneri list@ inicializacnenq iran
                return BadRequest(new MessageResponse
                {
                    Message = ex.Message
                });
            }
        }

    }
}
