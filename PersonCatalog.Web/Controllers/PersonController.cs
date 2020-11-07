using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Helpers;
using PersonCatalog.Domain.Interfaces.IServices;
using PersonCatalog.Domain.ResourceParameters;
using PersonCatalog.Web.Models;

namespace PersonCatalog.Web.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IPhoneService _phoneService;
        private readonly IRelationService _relationService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IPhoneService phoneService, IRelationService relationService, IMapper mapper)
        {
            _personService = personService;
            _phoneService = phoneService;
            _relationService = relationService;
            _mapper = mapper;
        }
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<PersonDTO>> GetPeople([FromQuery] PeopleResourceParameters parameters)
        {
            var result = _personService.SearchForPeople(parameters);
            foreach (var item in result)
            {
                item.Phones = _phoneService.Set().Where(a => a.PersonID == item.ID).ToList();
                item.RelativeTo = _relationService.Set().Where(a => a.PersonToID == item.ID || a.PersonFromID == item.ID).ToList();
            }

            var previousPageLink = result.HasPrevious ?
                CreatePeopleResourceUri(parameters,
                ResourceUriType.PreviousPage) : null;

            var nextPageLink = result.HasNext ?
                CreatePeopleResourceUri(parameters,
                ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = result.TotalCount,
                pageSize = result.PageSize,
                currentPage = result.CurrentPage,
                totalPages = result.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<PersonDTO>>(result));
        }

        [HttpGet("{id}", Name = "GetPerson")]
        [HttpHead]
        public IActionResult GetPerson(int id)
        //ActionResult Ienumerable<PersonDTO>
        {
            var person = _personService.Fetch(id);
            if (person == null)
            {
                return NotFound();
            }
            person.Phones = _phoneService.Set().Where(a => a.PersonID == person.ID).ToList();
            person.RelativeTo = _relationService.Set().Where(a => a.PersonToID == person.ID || a.PersonFromID == person.ID).ToList();

            return Ok(_mapper.Map<PersonDTO>(person));
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

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, PersonCreateDTO personDTO)
        {
            var person = _personService.Fetch(id);
            if (person == null)
            {
                return NotFound();
            }
            person.Name = personDTO.Name;
            person.Surname = personDTO.Surname;
            person.PersonalNumber = personDTO.PersonalNumber;
            person.BirthDate = personDTO.BirthDate;
            person.Gender = personDTO.Gender;

            person.Phones = _phoneService.Set().Where(a => a.PersonID == id).ToList();
            if (person.Phones == null)
            {
                foreach (var item in personDTO.Phones)
                {
                    var phone = _mapper.Map<PhoneNumber>(item);
                    _phoneService.Save(phone);
                }
            }
            else
            {
                person.Phones = _mapper.Map<List<PhoneNumber>>(personDTO.Phones);
            }
            _personService.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult patchAuthors(int id,
            JsonPatchDocument<PersonCreateDTO> patchDocument)
        {
            var person = _personService.Fetch(id);
            if (person == null)
            {
                return NotFound();
            }
            var peopleToPatch = _mapper.Map<PersonCreateDTO>(person);
            //add Validation
            patchDocument.ApplyTo(peopleToPatch, ModelState);

            if (!TryValidateModel(peopleToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(peopleToPatch, person);

            _personService.SaveChanges();


            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = _personService.Fetch(id);
            if (person == null)
            {
                return NotFound();
            }
            _personService.Delete(id);
            return NoContent();
        }

        //public IActionResult Update
        [HttpOptions]
        public IActionResult GetPeopleOptions()
        {
            Response.Headers.Add("Allow", "GET,Head,OPTIONS,POST,Delete");
            Response.Headers.Add("Enum:GenderType", "Male = 1,Female = 2");
            Response.Headers.Add("Enum:MobileType", "Mobile=1,Office=2,Home=3");
            Response.Headers.Add("Enum:RelativeType", "Colleague=1,Familiar=2,Relative=3,Other=4");
            return Ok();
        }

        private string CreatePeopleResourceUri(
           PeopleResourceParameters peopleResourceParameters,
           ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetAuthors",
                      new
                      {
                          pageNumber = peopleResourceParameters.PageNumber - 1,
                          pageSize = peopleResourceParameters.PageSize,
                          searchQuery = peopleResourceParameters.SearchName
                      });
                case ResourceUriType.NextPage:
                    return Url.Link("GetAuthors",
                      new
                      {
                          pageNumber = peopleResourceParameters.PageNumber + 1,
                          pageSize = peopleResourceParameters.PageSize,
                          searchQuery = peopleResourceParameters.SearchName
                      });

                default:
                    return Url.Link("GetAuthors",
                    new
                    {
                        pageNumber = peopleResourceParameters.PageNumber,
                        pageSize = peopleResourceParameters.PageSize,
                        searchQuery = peopleResourceParameters.SearchName
                    });
            }
        }
    }
}
