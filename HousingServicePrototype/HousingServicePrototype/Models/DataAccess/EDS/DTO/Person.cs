using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.DTO
{
    [DataContract]
    class Person
    {
        public Person() 
        {
            //EmployeeIncumbentPositions = new List<string>();
            //EmployeeOrganizationsReporting = new List<string>();
            //EmployeeTitles = new List<string>();
            //EmployeeRosterDepartments = new List<string>();
            //EmployeePositionsFunding = new List<string>();
            //EmployeePositionsFTE = new List<string>();
            EduPersonAffiliations = new List<string>();
            ObjectClasses = new List<string>();
            Memberships = new List<string>();
        }

        [DataMember(Name ="employeeprimaryaborcode")]
        public string EmployeePrimaryAborCode { get; set; }

        [DataMember(Name = "employeeincumbentposition")]
        public string EmployeeIncumbentPositions { get; set; }
        
        [DataMember(Name ="employeestatusdate")]
        public string EmployeeStatusDate { get; set; }

        [DataMember(Name ="employeeprimaryorgreporting")]
        public string EmployeePrimaryOrganizationReporting { get; set; }

        [DataMember(Name ="employeeorgreporting")]
        public string EmployeeOrganizationReporting { get; set; }

        [DataMember(Name ="employeetotalannualrate")]
        public decimal EmployeeTotalAnnualRate { get; set; }

        [DataMember(Name ="employeetitle")]
        public string EmployeeTitle { get; set; }

        [DataMember(Name ="employeeprimarytitle")]
        public string EmployeePrimaryTitle { get; set; }

        [DataMember(Name ="employeeofficialorgname")]
        public string EmployeeOfficialOrganizationName { get; set; }

        [DataMember(Name ="employeeofficialorg")]
        public string EmployeeOfficalOrganization { get; set; }

        [DataMember(Name ="employeehiredate")]
        public string EmployeeHireDate { get; set; }

        [DataMember(Name ="isonumber")]
        public long IsoNumber { get; set; }

        [DataMember(Name ="employeestate")]
        public string EmployeeState { get; set; }

        [DataMember(Name ="employeeroomnum")]
        public string EmployeeRoomNumber { get; set; }

        [DataMember(Name ="employeephone")]
        public string EmployeePhoneNumber { get; set; }

        [DataMember(Name ="uid")]
        public string NetId { get; set; }

        [DataMember(Name ="employeerosterdept")]
        public string EmployeeRosterDepartment { get; set; }

        [DataMember(Name ="employeepositionfunding")]
        public string EmployeePositionFunding { get; set; }

        [DataMember(Name ="employeeisferpatrained")]
        private string EmployeeIsFerpaTrainedString { get; set; }

        public bool EmployeeIsFerpaTrained 
        {
            get
            {
                if(string.IsNullOrEmpty(EmployeeIsFerpaTrainedString) || string.IsNullOrWhiteSpace(EmployeeIsFerpaTrainedString))
                    return false;

                if(EmployeeIsFerpaTrainedString.ToUpper() == "Y")
                    return true;
                else
                    return false;
            }            
        }

        [DataMember(Name ="employeepositionfte")]
        public string EmployeePositionsFTE { get; set; }

        [DataMember(Name ="employeefte")]
        public string EmployeeFTE { get; set; }

        [DataMember(Name ="employeepobox")]
        public string EmployeePOBox { get; set; }

        [DataMember(Name ="cn")]
        public string FullName { get; set; }

        [DataMember(Name ="dateofbirth")]
        public string Birthdate { get; set; }

        [DataMember(Name ="edupersonaffiliation")]
        public IList<string> EduPersonAffiliations { get; set; }

        [DataMember(Name ="edupersonprimaryaffiliation")]
        public string EduPersonPrimaryAffiliation { get; set; }

        [DataMember(Name ="emplid")]
        public int EmplId { get; set; }

        [DataMember(Name ="employeebldgname")]
        public string EmployeeBuildingName { get; set; }

        [DataMember(Name ="employeebldgnum")]
        public int EmployeeBuildingNumber { get; set; }

        [DataMember(Name ="employeeprimarydept")]
        public string EmployeePrimaryDepartment { get; set; }

        [DataMember(Name ="employeeprimarydeptname")]
        public string EmployeePrimaryDepartmentName { get; set; }

        [DataMember(Name ="employeestatus")]
        public string EmployeeStatus { get; set; }

        [DataMember(Name ="employeetype")]
        public string EmployeeType { get; set; }

        [DataMember(Name ="givenname")]
        public string FirstMiddleName { get; set; }

        [DataMember(Name ="mail")]
        public string Email { get; set; }

        [DataMember(Name ="objectclass")]
        public IList<string> ObjectClasses { get; set; }

        [DataMember(Name ="sn")]
        public string LastName { get; set; }

        [DataMember(Name ="uaid")]
        public string UniversityId { get; set; }
        
        [DataMember(Name ="ismemberof")]
        public IList<string> Memberships { get; set; }

        [DataMember(Name ="employeecity")]
        public string EmployeeCity { get; set; }

        [DataMember(Name ="employeezip")]
        public string EmployeePostalCode { get; set; }

        [DataMember(Name ="employeealternatetitle")]
        public string EmployeeAlternateTitle { get; set; }

        [DataMember(Name ="dn")]
        public string DN { get; set; }
    }
}
