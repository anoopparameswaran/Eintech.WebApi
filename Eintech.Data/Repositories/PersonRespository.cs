using Eintech.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eintech.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly EintechDbContext _eintechDbContext;
        public PersonRepository(EintechDbContext eintechDbContext)
        {
            _eintechDbContext = eintechDbContext;
        }
        /// <summary>
        /// Save new record in Person table
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<Person> Save(Person person)
        {
            var savedPerson =_eintechDbContext.People.Add(person);
            await _eintechDbContext.SaveChangesAsync();
            return savedPerson.Entity;
        }
    }
}
