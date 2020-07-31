using Eintech.WebApi.Entities;
using System;

namespace Eintech.Data
{
    public interface IPersonRepository
    {
        public void Save(Person person);
    }
}