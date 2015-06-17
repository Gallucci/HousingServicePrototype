using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.PersonService.DTO
{
    /// <summary>
    /// A Data Transfer Object (DTO) representing a person inside of the EDS Person Service.  This object acts a more user-friendly wrapper for the DSML DTO, an object which maps the DSML returned from a EDS Person Service API request.
    /// </summary>
    class Person
    {
        /// <summary>
        /// A Data Transfer Object (DTO) representing a person inside of the EDS Person Service.  This object acts a more user-friendly wrapper for the DSML DTO, an object which maps the DSML returned from a EDS Person Service API request.
        /// </summary>
        /// <param name="entry">The DSML DTO that containes the DSML returned from a EDS Person Service API request.</param>
        public Person(DsmlEntry entry)
        {
            // Initialize lists
            ObjectClasses = new List<string>();
            EduPersonAffiliations = new List<string>();            
            Memberships = new List<string>();

            // Prepare a dictionary of the DSML attributes to faciliate mapping
            var attributes = new Dictionary<string, IList<string>>();

            // Convert the DSML entry's attributes to a dictionary
            foreach(var attribute in entry.DirectoryEntry.Entry.Attributes)
            {
                var key = attribute.Name;
                var value = new List<string>(attribute.Values);                
                attributes.Add(key, value);
            }

            // Object classes are stored in their own list (since they have their own node in the DSML) so they need to be added seperately to the attribute dictionay
            var objectClassValues = new List<string>(entry.DirectoryEntry.Entry.ObjectClass.Values);
            attributes.Add("objectclass", objectClassValues);

            // Domain Name is stored as its own property (since it's an attribute in the DSML) so it needs to be added seperately to the attribute dictionary
            var domainName = new List<string>() { entry.DirectoryEntry.Entry.DomainName };
            attributes.Add("dn", domainName);

            // Map the attribute dictionary to the Person object
            MapProperties(this, attributes);
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
        public string DomainName { get; set; }

        /// <summary>
        /// Takes an object possessing properties marked with DataMapping attributes and attempts set those properties with the values in the dictionary using the attribute name in the DataMapping attribute as the key (case-insensitive).
        /// </summary>
        /// <param name="obj">An object possessing properties marked with the DataMapping attribute.</param>
        /// <param name="keyValuePairs">The list of key-value pairs whose values will be mapped to the object's properties.</param>
        private void MapProperties(object obj, Dictionary<string, IList<string>> keyValuePairs)
        {
            // Lower-case all keys in the the attribute dictionary to eliminate case-sensitivity
            var lowerCasePairs = new Dictionary<string, IList<string>>();
            foreach(var keyValuePair in keyValuePairs)
            {                
                lowerCasePairs.Add(keyValuePair.Key.ToLower(), keyValuePair.Value);
            }

            // Get the object's properties
            var type = obj.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            // Iterate through the object's properties
            foreach (var property in properties)
            {
                // For each property get any custom attributes, specifically the DataMapping attribute
                var customAttributes = property.GetCustomAttributes(false);
                var mappingAttribute = customAttributes.FirstOrDefault(a => a.GetType() == typeof(DataMappingAttribute));

                // If there's a DataMapping attribute present then begin work on its associated property
                if (mappingAttribute != null)
                {
                    // Get the name of the attribute that will be used as the key in the dictionary of attributes
                    var attribute = mappingAttribute as DataMappingAttribute;
                    var mapToAttributeName = attribute.AttributeName;

                    // If no attribute name was specified then try using the property name
                    if (string.IsNullOrEmpty(mapToAttributeName))
                        mapToAttributeName = property.Name;

                    // Lower-case the key name to eliminate case-sensitivity
                    var key = mapToAttributeName.ToLower();
                    var propertyType = property.PropertyType;

                    // If the specified attribute name exists in the attribute dictionary then do work with the associated property
                    if (lowerCasePairs.ContainsKey(key))
                    {
                        // A property of type IList has assigned to it the attribute dictionary's list of values for the given attribute
                        var values = lowerCasePairs[key];
                        if (propertyType == typeof(IList<string>))
                        {
                            property.SetValue(obj, values, null);
                        }

                        // A property of type string has assigned to it the first (and should be only) value in the attribute dictionary's list of values for the given attribute; parse value as string
                        if (propertyType == typeof(string))
                        {
                            if (values.Any())
                            {
                                var value = values.First().ToString();
                                property.SetValue(obj, value, null);
                            }
                        }

                        // A property of type integer has assigned to it the first (and should be only) value in the attribute dictionary's list of values for the given attribute; parse value as integer
                        if (propertyType == typeof(int))
                        {
                            if (values.Any())
                            {
                                var value = int.Parse(values.First());
                                property.SetValue(obj, value, null);
                            }
                        }

                        // A property of type double has assigned to it the first (and should be only) value in the attribute dictionary's list of values for the given attribute; parse value as double
                        if (propertyType == typeof(double))
                        {
                            if (values.Any())
                            {
                                var value = double.Parse(values.First());
                                property.SetValue(obj, value, null);
                            }
                        }

                        // A property of type long has assigned to it the first (and should be only) value in the attribute dictionary's list of values for the given attribute; parse value as long
                        if (propertyType == typeof(long))
                        {
                            if (values.Any())
                            {
                                var value = long.Parse(values.First());
                                property.SetValue(obj, value, null);
                            }
                        }

                        // A property of type decimal has assigned to it the first (and should be only) value in the attribute dictionary's list of values for the given attribute; parse value as decimal
                        if (propertyType == typeof(decimal))
                        {
                            if (values.Any())
                            {
                                var value = decimal.Parse(values.First());
                                property.SetValue(obj, value, null);
                            }
                        }

                        // A property of type bool has assigned to it the first (and should be only) value in the attribute dictionary's list of values for the given attribute; parse value as bool
                        if (propertyType == typeof(bool))
                        {
                            if (values.Any())
                            {
                                var value = bool.Parse(values.First());
                                property.SetValue(obj, value, null);
                            }
                        }

                        // A property of type DateTime has assigned to it the first (and should be only) value in the attribute dictionary's list of values for the given attribute; parse value as DateTime
                        if (propertyType == typeof(DateTime))
                        {
                            if (values.Any())
                            {
                                var value = DateTime.Parse(values.First());
                                property.SetValue(obj, value, null);
                            }
                        }
                    }
                }
            }
        }        
    }
}
