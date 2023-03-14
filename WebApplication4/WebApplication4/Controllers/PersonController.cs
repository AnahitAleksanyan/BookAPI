using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //public readonly IPersonRepository personRepository = PersonInstanceStorage.personListRepository;
        public readonly IPersonRepository personRepository = new PersonFileRepository();

        [HttpGet]
        public IEnumerable<Person> GetAll() 
        {
            var result = personRepository.GetPeople();
            Response.StatusCode = 200;
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Person?> GetById([FromRoute] int id)
        {
            return personRepository.GetPersonById(id);
        }

        [HttpPost]

        public ActionResult<Person> Create(PersonCreateDTO person)
        {
            Response.StatusCode = 201;
            return personRepository.CreatePerson(person);
        }

        [HttpPut]
        [SwaggerResponse(statusCode: 200, type: typeof(Person))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public ActionResult<dynamic> Update(PersonUpdateDTO person)
        {
            try
            {
                var result = personRepository.UpdatePerson(person);
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
            bool sucsess = personRepository.DeletePerson(id);
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
