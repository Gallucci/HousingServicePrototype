using HousingServicePrototype.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.Repository
{
    interface IPersonRepository
    {
        IEnumerable<Person> Get();
        Person Get(int id);
        void Add(Person person);
        void Update(Person person);
        void Delete(int id);
        void Save();
    }
}
