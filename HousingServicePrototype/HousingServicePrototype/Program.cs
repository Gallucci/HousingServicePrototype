using HousingServicePrototype.Models.Repository;
using HousingServicePrototype.Models.DataAccess.StarRez;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousingServicePrototype.Models.DataAccess;

namespace HousingServicePrototype
{
    class Program
    {        
        static void Main(string[] args)
        {
            var request = new GetEntryRequest.RequestBuilder()
                .AddSearchCriteria("ID1", "123456")
                .IncludeEntryAddressTable()
                .IncludeEntryDetailsTable()
                .IncludeBookingTable()
                .Build();

            var request2 = new GetEntryRequest.RequestBuilder("https", "myuahome.life.arizona.edu", "/StarRezREST/services/")
                .AddSearchCriteria("ID1", "99999999")
                .SetTopNumberOfRecords(1)
                .IncludeBookingTable()
                .Build();

            var starRezApi = new StarRezApi();
            var starRezResponse = starRezApi.GetEntry(request).Result;
            var entry = starRezResponse.Entries.First();
            IOHelper.WriteObjectProperties(entry);

            if (entry.Addresses.Any())
            {
                foreach (var address in entry.Addresses)
                {
                    IOHelper.WriteObjectProperties(address);
                }
            }

            if (entry.Details.Any())
            {
                foreach (var detail in entry.Details)
                {
                    IOHelper.WriteObjectProperties(detail);
                }
            }

            if(entry.Bookings.Any())
            {
                foreach (var booking in entry.Bookings)
                {
                    IOHelper.WriteObjectProperties(booking);
                }
            }

            //var pr = new PersonRepository();
            //var person = pr.Get(99999999);
            //IOHelper.WriteObjectProperties(person);
        }
    }
}
