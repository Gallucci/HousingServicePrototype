﻿using HousingServicePrototype.Models.DataAccess;
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
            var starRezApi = new StarRezApi();
            var starRezResponse = new ApiResponse();
            
            var starRezGetRequest = new GetEntryRequest.RequestBuilder()
                .AddSearchCriteria("ID1", id.ToString())
                .IncludeEntryAddressTable()
                .IncludeEntryDetailsTable()
                .Build();
            
            var entry = starRezResponse.Entries.First();

            AutoMapper.Mapper.CreateMap<Entry, Person>();
            var person = AutoMapper.Mapper.Map<Person>(entry);

            return person;
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