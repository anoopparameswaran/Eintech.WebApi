using Eintech.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Eintech.Data
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Save new record in Person table
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<Person> Save(Person person);
    }
}