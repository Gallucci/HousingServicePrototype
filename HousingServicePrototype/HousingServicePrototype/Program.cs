using HousingServicePrototype.Models.Repository;
using HousingServicePrototype.Models.DataAccess.StarRez;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousingServicePrototype.Models.DataAccess;
using HousingServicePrototype.Models.DataAccess.EDS;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.IO;

namespace HousingServicePrototype
{
    class Program
    {        
        static void Main(string[] args)
        {
            var starRezServiceScheme = ConfigHelper.GetStringValue("StarRezApiScheme");
            var starRezServiceHost = ConfigHelper.GetStringValue("StarRezApiHost");
            var starRezServicePath = ConfigHelper.GetStringValue("StarRezApiPath");

            var starRezRequest = new GetEntryRequest.GetEntryRequestBuilder(starRezServiceScheme, starRezServiceHost, starRezServicePath)
                .AddSearchCriteria("ID1", "01664073")
                .Build();

            var starRezRequest2 = new GetEntryRequest.GetEntryRequestBuilder("https", "myuahome.life.arizona.edu", "/StarRezREST/services/")
                .AddSearchCriteria("ID1", "99999999")
                .IncludeAddressTable()
                .IncludeDetailsTable()
                .IncludeBookingTable()
                .IncludeApplicationTable()
                .Build();

            Console.WriteLine(starRezRequest.RequestUrl);
            var starRezApi = new StarRezApi();
            var starRezResponse = starRezApi.GetResponse(starRezRequest).Result;

            if (starRezResponse.Entries.Any())
            {
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

            var edsServiceScheme = ConfigHelper.GetStringValue("EdsApiScheme");
            var edsServiceHost = ConfigHelper.GetStringValue("EdsApiHost");
            var edsRezServicePath = ConfigHelper.GetStringValue("EdsApiPath");

            var edsRequest = new GetPersonRequest.GetPersonRequestBuilder(edsServiceScheme, edsServiceHost, edsRezServicePath)
                .AddSearchCriteria("emplId", "16201293")
                .Build();

            Console.WriteLine(edsRequest.RequestUrl);
            var edsApi = new EdsApi();
            var edsResponse = edsApi.GetResponse(edsRequest).Result;
            //var edsResponse = edsApi.GetResponse("https://siaapps.uits.arizona.edu/home/web_services/edsLookup/16201293/emplId.json").Result;

            var person = edsResponse.Person;
            if (person != null)
            {
                IOHelper.WriteObjectProperties(person);

                if (person.EduPersonAffiliations.Any())
                {
                    foreach (var affiliations in person.EduPersonAffiliations)
                    {
                        Console.WriteLine(affiliations);
                    }
                }

                if (person.ObjectClasses.Any())
                {
                    foreach (var objectClass in person.ObjectClasses)
                    {
                        Console.WriteLine(objectClass);
                    }
                }

                if (person.Memberships.Any())
                {
                    foreach (var membership in person.Memberships)
                    {
                        Console.WriteLine(membership);
                    }
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); 
        }
    }
}
