using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAll()
        {
            var result = await _personService.GetPeople();
            Response.StatusCode = 200;
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person?>> GetById([FromRoute] int id)
        {
            try
            {
                return await _personService.GetPersonById(id);
            }
            catch (InvalidIdException)
            {
                return BadRequest(new MessageResponse()
                {
                    Message = "Id is invalid"
                });
            }

        }

        [HttpPost]

        [SwaggerResponse(statusCode: 201, type: typeof(Person))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public async Task<ActionResult<dynamic>> Create(PersonCreateDTO person)
        {
            try
            {
                return await _personService.CreatePerson(person);
            }
            catch (InvalidIdException)
            {
                return BadRequest(new MessageResponse
                {
                    Message = "invalid Id"
                });
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse
                {
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        [SwaggerResponse(statusCode: 200, type: typeof(Person))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public async Task<ActionResult<dynamic>> Update(PersonUpdateDTO person)
        {
            try
            {
                var result = await _personService.UpdatePerson(person);
                return result;
            }
            catch (InvalidIdException)
            {
                return BadRequest(new MessageResponse()
                {
                    Message = "Invalid id"
                });
            }
        }

        [HttpDelete]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            bool sucsess = await _personService.DeletePerson(id);
            if (sucsess)
            {
                return Ok(new MessageResponse
                {
                    Message = "Person has deleted!"
                });
            }
            else
            {
                return BadRequest(new MessageResponse
                {
                    Message = "Person is not deleted!"
                });
            }
        }
    }

}
