using Eintech.Data;
using Eintech.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Eintech.WebApi.Controllers
{
    public class PersonController : ControllerBase
    {
        private IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }
        /// <summary>
        /// Creates new person record
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [Route("api/person")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            
            var savedPerson = await _personRepository.Save(person);
            if(savedPerson != null)
                person.Id = savedPerson.Id;

            return Ok(person);
        }
    }
}