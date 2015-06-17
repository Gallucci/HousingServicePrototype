using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService.DTO
{
    class Person
    {
        public Person(DsmlEntry entry)
        {
            ObjectClasses = new List<string>();
            EduPersonAffiliations = new List<string>();            
            Memberships = new List<string>();

            var attributes = new Dictionary<string, IList<string>>();

            foreach(var attribute in entry.DirectoryEntry.Entry.Attributes)
            {
                var key = attribute.Name.ToLower();
                var value = new List<string>(attribute.Values);                
                attributes.Add(key, value);
            }

            var objectClassValues = new List<string>(entry.DirectoryEntry.Entry.ObjectClass.Values);
            attributes.Add("objectclass", objectClassValues);

            MapProperties(attributes);
        }
        
        [DataMapping("employeeprimaryaborcode")]
        public string EmployeePrimaryAborCode { get; set; }

        [DataMapping("employeeincumbentposition")]
        public string EmployeeIncumbentPositions { get; set; }

        [DataMapping("employeestatusdate")]
        public string EmployeeStatusDate { get; set; }

        [DataMapping("employeeprimaryorgreporting")]
        public string EmployeePrimaryOrganizationReporting { get; set; }

        [DataMapping("employeeorgreporting")]
        public string EmployeeOrganizationReporting { get; set; }

        [DataMapping("employeetotalannualrate")]
        public decimal EmployeeTotalAnnualRate { get; set; }

        [DataMapping("employeetitle")]
        public string EmployeeTitle { get; set; }

        [DataMapping("employeeprimarytitle")]
        public string EmployeePrimaryTitle { get; set; }

        [DataMapping("employeeofficialorgname")]
        public string EmployeeOfficialOrganizationName { get; set; }

        [DataMapping("employeeofficialorg")]
        public string EmployeeOfficalOrganization { get; set; }

        [DataMapping("employeehiredate")]
        public string EmployeeHireDate { get; set; }

        [DataMapping("isonumber")]
        public long IsoNumber { get; set; }

        [DataMapping("employeestate")]
        public string EmployeeState { get; set; }

        [DataMapping("employeeroomnum")]
        public string EmployeeRoomNumber { get; set; }

        [DataMapping("employeephone")]
        public string EmployeePhoneNumber { get; set; }

        [DataMapping("uid")]
        public string NetId { get; set; }

        [DataMapping("employeerosterdept")]
        public string EmployeeRosterDepartment { get; set; }

        [DataMapping("employeepositionfunding")]
        public string EmployeePositionFunding { get; set; }

        [DataMapping("employeeisferpatrained")]
        private string EmployeeIsFerpaTrainedString { get; set; }

        public bool EmployeeIsFerpaTrained
        {
            get
            {
                if (string.IsNullOrEmpty(EmployeeIsFerpaTrainedString) || string.IsNullOrWhiteSpace(EmployeeIsFerpaTrainedString))
                    return false;

                if (EmployeeIsFerpaTrainedString.ToUpper() == "Y")
                    return true;
                else
                    return false;
            }
        }

        [DataMapping("employeepositionfte")]
        public string EmployeePositionsFTE { get; set; }

        [DataMapping("employeefte")]
        public string EmployeeFTE { get; set; }

        [DataMapping("employeepobox")]
        public string EmployeePOBox { get; set; }

        [DataMapping("cn")]
        public string FullName { get; set; }

        [DataMapping("dateofbirth")]
        public string Birthdate { get; set; }

        [DataMapping("edupersonaffiliation")]
        public IList<string> EduPersonAffiliations { get; set; }

        [DataMapping("edupersonprimaryaffiliation")]
        public string EduPersonPrimaryAffiliation { get; set; }

        [DataMapping("emplid")]
        public int EmplId { get; set; }

        [DataMapping("employeebldgname")]
        public string EmployeeBuildingName { get; set; }

        [DataMapping("employeebldgnum")]
        public int EmployeeBuildingNumber { get; set; }

        [DataMapping("employeeprimarydept")]
        public string EmployeePrimaryDepartment { get; set; }

        [DataMapping("employeeprimarydeptname")]
        public string EmployeePrimaryDepartmentName { get; set; }

        [DataMapping("employeestatus")]
        public string EmployeeStatus { get; set; }

        [DataMapping("employeetype")]
        public string EmployeeType { get; set; }

        [DataMapping("givenname")]
        public string FirstMiddleName { get; set; }

        [DataMapping("mail")]
        public string Email { get; set; }

        [DataMapping("objectclass")]
        public IList<string> ObjectClasses { get; set; }

        [DataMapping("sn")]
        public string LastName { get; set; }

        [DataMapping("uaid")]
        public string UniversityId { get; set; }

        [DataMapping("ismemberof")]
        public IList<string> Memberships { get; set; }

        [DataMapping("employeecity")]
        public string EmployeeCity { get; set; }

        [DataMapping("employeezip")]
        public string EmployeePostalCode { get; set; }

        [DataMapping("employeealternatetitle")]
        public string EmployeeAlternateTitle { get; set; }

        [DataMapping("dn")]
        public string DN { get; set; }

        private void MapProperties(Dictionary<string, IList<string>> keyValuePairs)
        {
            var type = this.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var customAttributes = property.GetCustomAttributes(false);
                var mappingAttribute = customAttributes.FirstOrDefault(a => a.GetType() == typeof(DataMappingAttribute));

                if (mappingAttribute != null)
                {
                    var attribute = mappingAttribute as DataMappingAttribute;
                    var mapToAttributeName = attribute.AttributeName;                    

                    if (property != null)
                    {
                        var key = mapToAttributeName.ToLower();
                        var propertyType = property.PropertyType;

                        if (keyValuePairs.ContainsKey(key))
                        {
                            var values = keyValuePairs[key];
                            if (propertyType == typeof(IList<string>))
                            {
                                property.SetValue(this, values, null);
                            }

                            if (propertyType == typeof(string))
                            {
                                if (values.Any())
                                {
                                    var value = values.First().ToString();
                                    property.SetValue(this, value, null);
                                }
                            }

                            if (propertyType == typeof(int))
                            {
                                if (values.Any())
                                {
                                    var value = int.Parse(values.First());
                                    property.SetValue(this, value, null);
                                }
                            }

                            if (propertyType == typeof(double))
                            {
                                if (values.Any())
                                {
                                    var value = double.Parse(values.First());
                                    property.SetValue(this, value, null);
                                }
                            }

                            if (propertyType == typeof(long))
                            {
                                if (values.Any())
                                {
                                    var value = long.Parse(values.First());
                                    property.SetValue(this, value, null);
                                }
                            }

                            if (propertyType == typeof(decimal))
                            {
                                if (values.Any())
                                {
                                    var value = decimal.Parse(values.First());
                                    property.SetValue(this, value, null);
                                }
                            }

                            if (propertyType == typeof(bool))
                            {
                                if (values.Any())
                                {
                                    var value = bool.Parse(values.First());
                                    property.SetValue(this, value, null);
                                }
                            }

                            if (propertyType == typeof(DateTime))
                            {
                                if (values.Any())
                                {
                                    var value = DateTime.Parse(values.First());
                                    property.SetValue(this, value, null);
                                }
                            }
                        }
                    }
                }
            }
        }        
    }
}
