using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces.IServices;
using PersonCatalog.Web.Models;
using PersonCatalog.Web.ResourceParameters;

namespace PersonCatalog.Web.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<PersonDTO>> GetPeople([FromQuery] PeopleResourceParameters parameters)
            //IActionResult 
        {
            var result = _personService.GetPeopleByName(parameters.SearchName);
            return Ok(_mapper.Map<IEnumerable<PersonDTO>>(result));
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetPerson(int id)
            //ActionResult Ienumerable<PersonDTO>
        {
            var result = _personService.Fetch(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PersonDTO>(result));
        }

        [HttpPost]
        public IActionResult CreatePerson(PersonCreateDTO person)
        {
            var personEntity = _mapper.Map<Person>(person);
            _personService.Save(personEntity);
            
            var personToReturn = _mapper.Map<PersonDTO>(personEntity);
            return CreatedAtRoute("GetPerson", 
                new { id = personToReturn.ID },
                personToReturn);
        }
        //public IActionResult Update
        [HttpOptions]
        public IActionResult GetPeopleOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
    }
}
