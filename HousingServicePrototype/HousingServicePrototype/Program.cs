using HousingServicePrototype.Models.Repository;
using HousingServicePrototype.Models.DataAccess.StarRez;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype
{
    class Program
    {        
        static void Main(string[] args)
        {
            var pr = new PersonRepository();
            var person = pr.Get(99999999);

            IOHelper.WriteObjectProperties(person);

            //var starRezSearch = new EntrySearchRequest.SearchRequestBuilder("https", "myuahome.life.arizona.edu", "/StarRezREST/services/")
            //    .AddSearchCriteria("ID1", "99999999")
            //    .SetTopNumberOfRecords(5)
            //    .IncludeEntryAddressTable()
            //    .IncludeEntryDetailsTable()
            //    .Build();

            //Console.WriteLine(starRezSearch.ServiceUrl.ToString());
            //Console.WriteLine(starRezSearch.CommandUrl.ToString());
        }
    }
}
