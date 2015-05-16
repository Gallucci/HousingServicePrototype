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
            var request = new GetEntryRequest.GetEntryRequestBuilder()
                .AddSearchCriteria("ID1", "123456")
                .Build();

            var request2 = new GetEntryRequest.GetEntryRequestBuilder("https", "myuahome.life.arizona.edu", "/StarRezREST/services/")
                .AddSearchCriteria("ID1", "99999999")
                .IncludeAddressTable()
                .IncludeDetailsTable()
                .IncludeBookingTable()
                .IncludeApplicationTable()
                .Build();

            var api = new StarRezApi();
            var response = api.GetResponse(request).Result;

            if (response.Entries.Any())
            {
                var entry = response.Entries.First();
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

                if (entry.Bookings.Any())
                {
                    foreach (var booking in entry.Bookings)
                    {
                        IOHelper.WriteObjectProperties(booking);
                    }
                }

                if (entry.Applications.Any())
                {
                    foreach (var application in entry.Applications)
                    {
                        IOHelper.WriteObjectProperties(application);
                    }
                }
            }

            //// Using the Repository
            //var pr = new PersonRepository();
            //var person = pr.Get(123456);
            //IOHelper.WriteObjectProperties(person);
        }
    }
}
