using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.Domain
{
    class Person : IEntity
    {
        private int id;

        public int Id
        {
            get { return id; }
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Gender {get; set;}
        public string PreferredName { get; set; }
        public string BirthGender { get; set; }
        public IList<MailAddress> EmailAddresses { get; set;} 
        public IList<MailAddress> StreetAddresses { get; set; }
    }
}
