using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces.IServices;
using PersonCatalog.Web.Models;

namespace PersonCatalog.Web.Controllers
{
    [ApiController]
    public class RelationController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IPhoneService _phoneService;
        private readonly IRelationService _relationService;
        private readonly IMapper _mapper;

        public RelationController(IPersonService personService, IPhoneService phoneService, IRelationService relationService, IMapper mapper)
        {
            _personService = personService;
            _phoneService = phoneService;
            _relationService = relationService;
            _mapper = mapper;
        }
        [Route("api/people/{id}/relatives")]
        [HttpGet]
        public IActionResult GetRelativesForPerson(int id)
        {
            var person = _personService.Fetch(id);
            if (person == null)
            {
                return NotFound();
            }
            person.RelativeTo = _relationService.Set().Where(a => a.PersonToID == person.ID || a.PersonFromID == person.ID).ToList();

            return Ok(_mapper.Map<IEnumerable<RelativeDTO>>(person.RelativeTo));
        }

        [Route("api/relatives/{id}", Name = "GetRelatives")]
        [HttpGet]
        public IActionResult GetRelativesByID(int id)
        {
            var relative = _relationService.Set().Where(a => a.ID == id);
            if (relative == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<RelativeDTO>>(relative));
        }

        [HttpPost]
        [Route("api/relatives")]
        public IActionResult CreateRelativesForPerson(RelativeCreateDTO relativesDTO)
        {
            var firstPerson = _personService.Fetch(relativesDTO.PersonToID);
            var secondPerson = _personService.Fetch(relativesDTO.PersonFromID);
            if (firstPerson == null || secondPerson == null)
            {
                return NotFound();
            }
            var relative = _relationService.Set().Where(a =>
            (a.PersonFromID == firstPerson.ID || a.PersonToID == secondPerson.ID) ||
            (a.PersonFromID == secondPerson.ID || a.PersonToID == firstPerson.ID))
                .FirstOrDefault();

            if (relative != null)
            {
                return NotFound();
            }
            relative = _mapper.Map<Relation>(relativesDTO);
            _relationService.Save(relative);

            var relativeToReturn = _mapper.Map<RelativeDTO>(relative);
            return CreatedAtRoute("GetRelatives",
               new { id = relativeToReturn.ID },
               relativeToReturn);
        }

        [Route("api/relatives/{id}")]
        [HttpDelete]
        public IActionResult DeleteRelativesForPerson(int id)
        {
            var relative = _relationService.Set().Where(a =>
            a.ID == id).FirstOrDefault();
            if (relative == null)
            {
                return NotFound();
            }
            _relationService.Delete(relative);

            return NoContent();
        }
    }
}
