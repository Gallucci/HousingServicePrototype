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
            InformationReleaseCodes = new List<string>();
            StudentStatusHistory = new List<string>();
            DccRelations = new List<string>();

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
        
        /// <summary>
        /// Employee's primary ABOR code.  For more information see EDS eduPersonAffiliation Overview (http://iia.arizona.edu/eds_attributes).
        /// </summary>
        [DataMapping("employeePrimaryAborCode")]
        public string EmployeePrimaryAborCode { get; set; }

        /// <summary>
        /// A colon (:) separated list with an employee's title, Position Control Number (PCN) from UAccess Employee (######), start date for the position (YYYYMMDD), Employee Type, and Employee Status (see descriptions of employeeType and employeeStatus for values)
        /// </summary>
        [DataMapping("employeeIncumbentPosition")]
        public string EmployeeIncumbentPositions { get; set; }

        /// <summary>
        /// Date when an employee's current status began, in the format YYYYMMDD.
        /// </summary>
        [DataMapping("employeeStatusDate")]
        public string EmployeeStatusDate { get; set; }

        /// <summary>
        /// Reason for employee termination.  For reasons, see employeeTerminationReason Table (http://iia.arizona.edu/eds_attributes#employeeterminationreason).
        /// </summary>
        [DataMapping("employeeTerminationReason")]
        public string EmployeeTerminationReason { get; set; }

        /// <summary>
        /// Person's preferred full name (first name middle initial-or-name last name).
        /// </summary>
        [DataMapping("preferredCn")]
        public string PreferredFullName { get; set; }

        /// <summary>
        /// Person's preferred last name.
        /// </summary>
        [DataMapping("preferredSn")]
        public string PreferredLastName { get; set; }

        /// <summary>
        /// A colon (:) separated list containing a PCN (position control number), the Roster Department number for that position, the college to which the employee reports (formatted as college code and college description, separated by a dash (-)), and the VP to which the employee reports (formatted as VP code and VP description, separated by a dash (-)).
        /// </summary>
        [DataMapping("employeePrimaryOrgReporting")]
        public string EmployeePrimaryOrganizationReporting { get; set; }

        /// <summary>
        /// A colon (:) separated list containing a PCN (position control number), the Roster Department number for that position, the college to which the employee reports (formatted as college code and college description, separated by a dash (-)), and the VP to which the employee reports (formatted as VP code and VP description, separated by a dash (-)).
        /// </summary>
        [DataMapping("employeeOrgReporting")]
        public string EmployeeOrganizationReporting { get; set; }

        /// <summary>
        /// Total annual salary of an employee (actual, not normalized to 1.0 FTE).
        /// </summary>
        [DataMapping("employeeTotalAnnualRate")]
        public decimal EmployeeTotalAnnualRate { get; set; }

        /// <summary>
        /// All current employee titles, including titles for incumbent positions.
        /// </summary>
        [DataMapping("employeeTitle")]
        public string EmployeeTitle { get; set; }

        /// <summary>
        /// Retiree title.
        /// </summary>
        [DataMapping("employeeRetireeTitle")]
        public string EmployeeRetireeTitle { get; set; }

        /// <summary>
        /// Employee primary title from among all their incumbent positions.
        /// </summary>
        [DataMapping("employeePrimaryTitle")]
        public string EmployeePrimaryTitle { get; set; }

        /// <summary>
        /// Official organization name for an employee.
        /// </summary>
        [DataMapping("employeeOfficialOrgName")]
        public string EmployeeOfficialOrganizationName { get; set; }

        /// <summary>
        ///  Official organization code for an employee.
        /// </summary>
        [DataMapping("employeeOfficialOrg")]
        public string EmployeeOfficalOrganization { get; set; }

        /// <summary>
        /// Most recent start of employment date for an employee.  For an employee who has left the university and subsequently been re-hired, this reflects the most recent hire date, not the original hire date.
        /// </summary>
        [DataMapping("employeeHireDate")]
        public string EmployeeHireDate { get; set; }

        /// <summary>
        /// Sixteen-digit ISO number from person's CatCard.
        /// </summary>
        [DataMapping("isoNumber")]
        public long IsoNumber { get; set; }

        /// <summary>
        /// Employee's work address state.
        /// </summary>
        [DataMapping("employeeState")]
        public string EmployeeState { get; set; }

        /// <summary>
        /// Room number associated with an employee's primary office.
        /// </summary>
        [DataMapping("employeeRoomNum")]
        public string EmployeeRoomNumber { get; set; }

        /// <summary>
        /// UA phone number of an employee in the format ##########.
        /// </summary>
        [DataMapping("employeePhone")]
        public string EmployeePhoneNumber { get; set; }

        /// <summary>
        /// Person's UA NetID username.
        /// </summary>
        [DataMapping("uid")]
        public string NetId { get; set; }

        /// <summary>
        /// Dept # of department to which an employee submits their timesheet. Each instance of this attribute will contain a PCN (position control number), and the Roster Department number for that position, separated by a colon (':').
        /// </summary>
        [DataMapping("employeeRosterDept")]
        public string EmployeeRosterDepartment { get; set; }

        /// <summary>
        /// A colon (:) separated list containing the UAccess Employee position control number (PCN) and the funding department number. For each position an employee occupies there will be at least one corresponding value in this attribute if the position is funded; non-funded positions will not appear in the value set of this attribute.  Positions funded by multiple departments will have multiple values in this attribute
        /// </summary>
        [DataMapping("employeePositionFunding")]
        public string EmployeePositionFunding { get; set; }

        /// <summary>
        /// Indicates FERPA training, "Y" for employees who have had FERPA training and "N" for employees who have not.
        /// </summary>
        [DataMapping("employeeIsFerpaTrained")]
        private string EmployeeIsFerpaTrainedString { get; set; }

        /// <summary>
        /// Percentage of an employee's FTE for an incumbent position.
        /// </summary>
        [DataMapping("employeePositionFte")]
        public string EmployeePositionsFTE { get; set; }

        /// <summary>
        /// FTE for the employee as a whole.  Note: this is more complex than just summing the FTE percentages from the incumbent positions.
        /// </summary>
        [DataMapping("employeeFte")]
        public string EmployeeFTE { get; set; }

        /// <summary>
        /// Post Office Box number of an employee's work-related mailing address.
        /// </summary>
        [DataMapping("employeePoBox")]
        public string EmployeePOBox { get; set; }

        /// <summary>
        /// Full name (first name middle initial-or-name last name).
        /// </summary>
        [DataMapping("cn")]
        public string FullName { get; set; }

        /// <summary>
        /// Date of birth in format YYYYMMDD.
        /// </summary>
        [DataMapping("dateOfBirth")]
        public string Birthdate { get; set; }

        /// <summary>
        /// University affiliation.  For information on the use of these attributes, see the EDS eduPersonAffiliation Overview (http://iia.arizona.edu/eds_attributes#edupersonaffiliationoverview).
        /// </summary>
        [DataMapping("eduPersonAffiliation")]
        public IList<string> EduPersonAffiliations { get; set; }

        /// <summary>
        /// Primary University affiliation.  For information on primary affiliation, see EDS eduPersonPrimaryAffiliation Determination (http://iia.arizona.edu/eds_attributes#primaryaffiliationdetermination).
        /// </summary>
        [DataMapping("eduPersonPrimaryAffiliation")]
        public string EduPersonPrimaryAffiliation { get; set; }

        /// <summary>
        /// Eight-digit number that is the primary identifier on campus. The EMPLID is a common identifier that will be shared between UAccess Student and Uaccess Employee.
        /// </summary>
        [DataMapping("emplId")]
        public int EmplId { get; set; }

        /// <summary>
        /// Name of the building that corresponds to an employee's primary department.
        /// </summary>
        [DataMapping("employeeBldgName")]
        public string EmployeeBuildingName { get; set; }

        /// <summary>
        /// Number of the building that corresponds to an employee's primary department.
        /// </summary>
        [DataMapping("employeeBldgNum")]
        public int EmployeeBuildingNumber { get; set; }

        /// <summary>
        /// Contains the text description of a student's career program plan and the format is "Career - Program - Plan" 
        /// </summary>
        [DataMapping("studentAPDesc")]
        public string StudentCareerPlanDescription { get; set; }

        /// <summary>
        /// Contains current and future admit career program plans with these colon (:) delimited items.  For more information, see Career Program Plan (http://iia.arizona.edu/eds_attributes#cpptable).
        /// </summary>
        [DataMapping("studentPrimaryCareerProgramPlan")]
        public string PrimaryStudentCareerProgramPlan { get; set; }

        /// <summary>
        /// If student is, or has previously been, a member of the Honors College, this attribute will be present and reflect their current status in the Honors program. Y indicates "active" and N indicates "inactive".
        /// </summary>
        [DataMapping("studentHonorsActive")]
        public string StudentHonorsActive { get; set; }

        /// <summary>
        /// Contains one or more values representing items of student information not to be released.  For code descriptions, see studentInfoRelease Codes (http://iia.arizona.edu/eds_attributes#employeetype).
        /// </summary>
        [DataMapping("studentInfoReleaseCode")]
        public IList<string> InformationReleaseCodes { get; set; }

        /// <summary>
        /// Contains past values of the studentStatus attribute.
        /// </summary>
        [DataMapping("studentStatusHistory")]
        public IList<string> StudentStatusHistory { get; set; }

        /// <summary>
        /// Person's preferred given name (first name and middle initial-or-name).
        /// </summary>
        [DataMapping("preferredGivenname")]
        public string PreferredFirstMiddleName { get; set; }

        /// <summary>
        /// Dept # of employee's primary department (also known as home department); refers to the department where an employee's paycheck is sent.
        /// </summary>
        [DataMapping("employeePrimaryDept")]
        public string EmployeePrimaryDepartment { get; set; }

        /// <summary>
        /// Textual description corresponding to employeePrimaryDept.
        /// </summary>
        [DataMapping("employeePrimaryDeptName")]
        public string EmployeePrimaryDepartmentName { get; set; }

        /// <summary>
        /// UAccess Employee status codes.  For code descriptions, see employeeStatus Codes (http://iia.arizona.edu/eds_attributes#employeestatus).
        /// </summary>
        [DataMapping("employeeStatus")]
        public string EmployeeStatus { get; set; }

        /// <summary>
        /// One-character code from UAccess Employee that identifies  the type of an employment.  For type descriptions, see employeeType Descriptions (http://iia.arizona.edu/eds_attributes#employeetype).
        /// </summary>
        [DataMapping("employeeType")]
        public string EmployeeType { get; set; }

        /// <summary>
        /// First name and middle initial-or-name.
        /// </summary>
        [DataMapping("givenName")]
        public string FirstMiddleName { get; set; }

        /// <summary>
        /// UA email address.
        /// </summary>
        [DataMapping("mail")]
        public string Email { get; set; }

        /// <summary>
        /// Primary action date for a DCC and the start date for new DCCs. it can be a future date, in which case the dccStatus will be 'F'.
        /// </summary>
        [DataMapping("dccPrimaryActionDate")]
        public string DccPrimaryActionDate { get; set; }

        /// <summary>
        /// Primary department code for a DCC.
        /// </summary>
        [DataMapping("dccPrimaryDept")]
        public string DccPrimaryDepartment { get; set; }

        /// <summary>
        /// Primary department name for a DCC.
        /// </summary>
        [DataMapping("dccPrimaryDeptName")]
        public string DccPrimaryDepartmentName { get; set; }

        /// <summary>
        /// Primary end date for the DCC relationship.
        /// </summary>
        [DataMapping("dccPrimaryEndDate")]
        public string DccPrimaryEndDate { get; set; }

        /// <summary>
        /// Primary status of the DCC.  For status values, see dccPrimaryStatus Values (http://iia.arizona.edu/eds_attributes#dccprimarystatus).
        /// </summary>
        [DataMapping("dccPrimaryStatus")]
        public string DccPrimaryStatus { get; set; }

        /// <summary>
        /// Primary title of the DCC.
        /// </summary>
        [DataMapping("dccPrimaryTitle")]
        public string DccPrimaryTitle { get; set; }

        /// <summary>
        /// Primary type of the DCC.  For DCC type values, see the DCC Types Table (http://iia.arizona.edu/eds_attributes#dcctypes).
        /// </summary>
        [DataMapping("dccPrimaryType")]
        public string DccPrimaryType { get; set; }

        /// <summary>
        /// The subcategory code for the primary DCC relationship, if (and only if) the primary DCC relationship type has a subcategory (else the attribute will not be present).  For DCC type values, see the DCC Types Table (http://iia.arizona.edu/eds_attributes#dcctypes).
        /// </summary>
        [DataMapping("dccPrimarySubCategory")]
        public string DccPrimarySubCategory { get; set; }

        /// <summary>
        ///A DCC's relationship(s) with the University representated as a colon (:) separated list consisting of the DCC's title, type, department, department name, status, action date, end date, and subcategory code (if any).  For DCC type values, see the DCC Types Table (http://iia.arizona.edu/eds_attributes#dcctypes).
        /// </summary>
        [DataMapping("dccRelation")]
        public IList<string> DccRelations { get; set; }

        /// <summary>
        /// UAID of a DSV that has converted to a DCC.
        /// </summary>
        [DataMapping("dsvUAID")]
        public string DsvUaId { get; set; }

        /// <summary>
        /// LDAP object classes identify the type of a directory entry. Object classes define the mandatory and optional attributes an entry of a specific type may carry.
        /// </summary>
        [DataMapping("objectClass")]
        public IList<string> ObjectClasses { get; set; }

        /// <summary>
        ///  Last name.
        /// </summary>
        [DataMapping("sn")]
        public string LastName { get; set; }

        /// <summary>
        /// Uniquely identifies each UA-affiliated person.
        /// </summary>
        [DataMapping("uaid")]
        public string UniversityId { get; set; }

        /// <summary>
        /// Each value is the DN of a group the person is a member of.  For more information, see Course Groups (http://iia.arizona.edu/coursegroups).
        /// </summary>
        [DataMapping("isMemberOf")]
        public IList<string> Memberships { get; set; }

        /// <summary>
        /// Employee's work address city.
        /// </summary>
        [DataMapping("employeeCity")]
        public string EmployeeCity { get; set; }

        /// <summary>
        /// Employee's work address zip code.
        /// </summary>
        [DataMapping("employeeZip")]
        public string EmployeePostalCode { get; set; }

        /// <summary>
        /// Alternate employee title.
        /// </summary>
        [DataMapping("employeeAlternateTitle")]
        public string EmployeeAlternateTitle { get; set; }

        /// <summary>
        /// Domain name?
        /// </summary>
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
