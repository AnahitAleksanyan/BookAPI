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
            _personService = personService;    //stex harc unim 
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            var result = _personService.GetPeople();
            Response.StatusCode = 200;
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Person?> GetById([FromRoute] int id)
        {
            return _personService.GetPersonById(id);
        }

        [HttpPost]

        [SwaggerResponse(statusCode: 201, type:typeof(Person))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public ActionResult<dynamic> Create(PersonCreateDTO person)
        {
            try
            {              
                return _personService.CreatePerson(person);
            }
            catch (InvalidIdException)
            {
                return BadRequest(new MessageResponse
                {
                    Message = "invalid Id"
                });
            }
        }

        [HttpPut]
        [SwaggerResponse(statusCode: 200, type: typeof(Person))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public ActionResult<dynamic> Update(PersonUpdateDTO person)
        {
            try
            {
                var result = _personService.UpdatePerson(person);
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
        public ActionResult<MessageResponse> Delete(int id)
        {
            bool sucsess = _personService.DeletePerson(id);
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
