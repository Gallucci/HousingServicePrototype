using HousingServicePrototype.Models.DataAccess;
using HousingServicePrototype.Models.DataAccess.StarRez;
using HousingServicePrototype.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.Repository
{
    class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> Get()
        {
            throw new NotImplementedException();
        }

        //public Person Get(int id)
        //{
        //    var starRezApi = new StarRezApi();
        //    var starRezResponse = new ApiResponse();

        //    starRezResponse = starRezApi.GetEntry("ID1", id.ToString()).Result;
        //    var entry = starRezResponse.Entries.First();

        //    AutoMapper.Mapper.CreateMap<Entry, Person>();
        //    var person = AutoMapper.Mapper.Map<Person>(entry);

        //    return person;
        //}

        public Person Get(int id)
        {
            // Use the StarRez GetEntryRequest builder to build the URL request
            var request = new GetEntryRequest.RequestBuilder()
                .AddSearchCriteria("ID1", id.ToString())
                .IncludeAddressTable()
                .IncludeDetailsTable()
                .IncludeBookingTable()
                .Build();

            // Send the request and get the response
            var api = new StarRezApi();
            var response = api.GetResponse(request).Result;

            if (response.Entries.Any())
            {
                var entry = response.Entries.First();

                // Map the entry to a person
                AutoMapper.Mapper.CreateMap<Entry, Person>();
                var person = AutoMapper.Mapper.Map<Person>(entry);

                return person;
            }
            else
                throw new Exception(string.Format("Could not find person with ID [{0}]", id.ToString()));
        }
 
        public void Add(Person person)
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
