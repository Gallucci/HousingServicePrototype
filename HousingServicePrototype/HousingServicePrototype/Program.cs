using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.IO;
using HousingServicePrototype.Models.DataAccess.EDS.LookupService;
using HousingServicePrototype.Models.DataAccess.EDS.PersonService;
using HousingServicePrototype.Models.DataAccess.StarRez;
using HousingServicePrototype.Models.DataAccess;

namespace HousingServicePrototype
{
    class Program
    {        
        static void Main(string[] args)
        {
            // STARREZ SERVICE (JSON-BASED)
            var starRezServiceScheme = ConfigHelper.GetStringValue("StarRezApiScheme");
            var starRezServiceHost = ConfigHelper.GetStringValue("StarRezApiHost");
            var starRezServicePath = ConfigHelper.GetStringValue("StarRezApiPath");

            //var starRezRequest = new GetEntryRequest.GetEntryRequestBuilder(starRezServiceScheme, starRezServiceHost, starRezServicePath)
            //    .AddSearchCriteria("ID1", "01664073")
            //    .Build();

            var starRezRequest = new GetEntryRequest.GetEntryRequestBuilder("https", "myuahome.life.arizona.edu", "/StarRezREST/services/")
                .AddSearchCriteria("ID1", "01664073")
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

            // EDS LOOKUP SERVICE (JSON-BASED)
            var edsLookupServiceScheme = ConfigHelper.GetStringValue("EdsLookupApiScheme");
            var edsLookupServiceHost = ConfigHelper.GetStringValue("EdsLookupApiHost");
            var edsLookupServicePath = ConfigHelper.GetStringValue("EdsLookupApiPath");

            var edsLookupServiceRequest = new HousingServicePrototype.Models.DataAccess.EDS.LookupService.GetPersonRequest.GetPersonRequestBuilder(edsLookupServiceScheme, edsLookupServiceHost, edsLookupServicePath)
                .AddSearchCriteria("emplId", "16201293")
                .Build();

            Console.WriteLine();
            Console.WriteLine(edsLookupServiceRequest.RequestUrl);
            var edsLookupServiceApi = new HousingServicePrototype.Models.DataAccess.LookupService.EDS.EdsApi();
            var edsLookupServiceResponse = edsLookupServiceApi.GetResponse(edsLookupServiceRequest).Result;
            //var edsLookupServiceResponse = edsApi.GetResponse("https://siaapps.uits.arizona.edu/home/web_services/edsLookup/16201293/emplId.json").Result;

            var edsLookupServicePerson = edsLookupServiceResponse.Person;
            if (edsLookupServicePerson != null)
            {
                IOHelper.WriteObjectProperties(edsLookupServicePerson);

                if (edsLookupServicePerson.EduPersonAffiliations.Any())
                {
                    foreach (var affiliations in edsLookupServicePerson.EduPersonAffiliations)
                    {
                        Console.WriteLine(affiliations);
                    }
                }

                if (edsLookupServicePerson.ObjectClasses.Any())
                {
                    foreach (var objectClass in edsLookupServicePerson.ObjectClasses)
                    {
                        Console.WriteLine(objectClass);
                    }
                }

                if (edsLookupServicePerson.Memberships.Any())
                {
                    foreach (var membership in edsLookupServicePerson.Memberships)
                    {
                        Console.WriteLine(membership);
                    }
                }
            }            

            // EDS PERSON SERVICE (DSML-BASED)
            var edsPersonServiceScheme = ConfigHelper.GetStringValue("EdsPersonApiScheme");
            var edsPersonServiceHost = ConfigHelper.GetStringValue("EdsPersonApiHost");
            var edsPersonServicePath = ConfigHelper.GetStringValue("EdsPersonApiPath");
            var edsPersonServiceApi = new HousingServicePrototype.Models.DataAccess.EDS.PersonService.EdiApi();

            var edsPersonServiceRequest = new HousingServicePrototype.Models.DataAccess.EDS.PersonService.GetPersonRequest.GetPersonRequestBuilder(edsPersonServiceScheme, edsPersonServiceHost, edsPersonServicePath)
                .SearchByEmplId("16201293")
                .Build();

            Console.WriteLine();
            Console.WriteLine(edsPersonServiceRequest.RequestUrl);
            var edsPersonServiceResponse = edsPersonServiceApi.GetResponse(edsPersonServiceRequest).Result;
            //var edsPersonServiceResponse = edsPersonServiceApi.GetResponse("https://eds.arizona.edu/people/16201293").Result;

            var edsPersonServicePerson = edsPersonServiceResponse.Person;
            if (edsPersonServicePerson != null)
            {
                IOHelper.WriteObjectProperties(edsPersonServicePerson);

                if (edsPersonServicePerson.EduPersonAffiliations.Any())
                {
                    foreach (var affiliations in edsPersonServicePerson.EduPersonAffiliations)
                    {
                        Console.WriteLine(affiliations);
                    }
                }

                if (edsPersonServicePerson.ObjectClasses.Any())
                {
                    foreach (var objectClass in edsPersonServicePerson.ObjectClasses)
                    {
                        Console.WriteLine(objectClass);
                    }
                }

                if (edsPersonServicePerson.Memberships.Any())
                {
                    foreach (var membership in edsPersonServicePerson.Memberships)
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
