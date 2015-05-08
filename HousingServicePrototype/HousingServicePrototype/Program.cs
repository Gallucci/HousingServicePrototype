using HousingServicePrototype.Models.DataAccess;
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
            var starRezApi = new StarRezApi();
            var starRezResponse = new ApiResponse();

            starRezResponse = starRezApi.GetEntry("99999999").Result;

            if (starRezResponse.Success)
            {
                foreach (var starRezEntry in starRezResponse.Entries)
                {                    
                    IOHelper.WriteObjectProperties(starRezEntry);
                }
            }
            else
                Console.WriteLine(starRezResponse.ErrorMessage);
        }
    }
}
