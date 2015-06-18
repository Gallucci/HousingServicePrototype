using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype.Models.DataAccess.EDS.LookupService.DTO
{
    /// <summary>
    /// A Data Transfer Object (DTO) representing a person inside of the EDS Lookup Service.
    /// </summary>
    [DataContract]
    class Person
    {
        /// <summary>
        /// A Data Transfer Object (DTO) representing a person inside of the EDS Lookup Service.  Maps the JSON returned from a Lookup Service API request.
        /// </summary>
        public Person() 
        {
            // Initialize lists
            ObjectClasses = new List<string>();
            EduPersonAffiliations = new List<string>();
            Memberships = new List<string>();
            InformationReleaseCodes = new List<string>();
            StudentStatusHistory = new List<string>();
            DccRelations = new List<string>();
        }

        /// <summary>
        /// Employee's primary ABOR code.  For more information see EDS eduPersonAffiliation Overview (http://iia.arizona.edu/eds_attributes).
        /// </summary>
        [DataMember(Name = "employeePrimaryAborCode")]
        public string EmployeePrimaryAborCode { get; set; }

        /// <summary>
        /// A colon (:) separated list with an employee's title, Position Control Number (PCN) from UAccess Employee (######), start date for the position (YYYYMMDD), Employee Type, and Employee Status (see descriptions of employeeType and employeeStatus for values)
        /// </summary>
        [DataMember(Name = "employeeIncumbentPosition")]
        public string EmployeeIncumbentPositions { get; set; }

        /// <summary>
        /// Date when an employee's current status began, in the format YYYYMMDD.
        /// </summary>
        [DataMember(Name = "employeeStatusDate")]
        public string EmployeeStatusDate { get; set; }

        /// <summary>
        /// Reason for employee termination.  For reasons, see employeeTerminationReason Table (http://iia.arizona.edu/eds_attributes#employeeterminationreason).
        /// </summary>
        [DataMember(Name = "employeeTerminationReason")]
        public string EmployeeTerminationReason { get; set; }

        /// <summary>
        /// Person's preferred full name (first name middle initial-or-name last name).
        /// </summary>
        [DataMember(Name = "preferredCn")]
        public string PreferredFullName { get; set; }

        /// <summary>
        /// Person's preferred last name.
        /// </summary>
        [DataMember(Name = "preferredSn")]
        public string PreferredLastName { get; set; }

        /// <summary>
        /// A colon (:) separated list containing a PCN (position control number), the Roster Department number for that position, the college to which the employee reports (formatted as college code and college description, separated by a dash (-)), and the VP to which the employee reports (formatted as VP code and VP description, separated by a dash (-)).
        /// </summary>
        [DataMember(Name = "employeePrimaryOrgReporting")]
        public string EmployeePrimaryOrganizationReporting { get; set; }

        /// <summary>
        /// A colon (:) separated list containing a PCN (position control number), the Roster Department number for that position, the college to which the employee reports (formatted as college code and college description, separated by a dash (-)), and the VP to which the employee reports (formatted as VP code and VP description, separated by a dash (-)).
        /// </summary>
        [DataMember(Name = "employeeOrgReporting")]
        public string EmployeeOrganizationReporting { get; set; }

        /// <summary>
        /// Total annual salary of an employee (actual, not normalized to 1.0 FTE).
        /// </summary>
        [DataMember(Name = "employeeTotalAnnualRate")]
        public decimal EmployeeTotalAnnualRate { get; set; }

        /// <summary>
        /// All current employee titles, including titles for incumbent positions.
        /// </summary>
        [DataMember(Name = "employeeTitle")]
        public string EmployeeTitle { get; set; }

        /// <summary>
        /// Employee primary title from among all their incumbent positions.
        /// </summary>
        [DataMember(Name = "employeePrimaryTitle")]
        public string EmployeePrimaryTitle { get; set; }

        /// <summary>
        /// Retiree title.
        /// </summary>
        [DataMember(Name = "employeeRetireeTitle")]
        public string EmployeeRetireeTitle { get; set; }

        /// <summary>
        /// Official organization name for an employee.
        /// </summary>
        [DataMember(Name = "employeeOfficialOrgName")]
        public string EmployeeOfficialOrganizationName { get; set; }

        /// <summary>
        ///  Official organization code for an employee.
        /// </summary>
        [DataMember(Name = "employeeOfficialOrg")]
        public string EmployeeOfficalOrganization { get; set; }

        /// <summary>
        /// Most recent start of employment date for an employee.  For an employee who has left the university and subsequently been re-hired, this reflects the most recent hire date, not the original hire date.
        /// </summary>
        [DataMember(Name = "employeeHireDate")]
        public string EmployeeHireDate { get; set; }

        /// <summary>
        /// Sixteen-digit ISO number from person's CatCard.
        /// </summary>
        [DataMember(Name = "isoNumber")]
        public long IsoNumber { get; set; }

        /// <summary>
        /// Employee's work address state.
        /// </summary>
        [DataMember(Name = "employeeState")]
        public string EmployeeState { get; set; }

        /// <summary>
        /// Room number associated with an employee's primary office.
        /// </summary>
        [DataMember(Name = "employeeRoomNum")]
        public string EmployeeRoomNumber { get; set; }

        /// <summary>
        /// UA phone number of an employee in the format ##########.
        /// </summary>
        [DataMember(Name = "employeePhone")]
        public string EmployeePhoneNumber { get; set; }

        /// <summary>
        /// Person's UA NetID username.
        /// </summary>
        [DataMember(Name = "uid")]
        public string NetId { get; set; }

        /// <summary>
        /// Dept # of department to which an employee submits their timesheet. Each instance of this attribute will contain a PCN (position control number), and the Roster Department number for that position, separated by a colon (':').
        /// </summary>
        [DataMember(Name = "employeeRosterDept")]
        public string EmployeeRosterDepartment { get; set; }

        /// <summary>
        /// A colon (:) separated list containing the UAccess Employee position control number (PCN) and the funding department number. For each position an employee occupies there will be at least one corresponding value in this attribute if the position is funded; non-funded positions will not appear in the value set of this attribute.  Positions funded by multiple departments will have multiple values in this attribute
        /// </summary>
        [DataMember(Name = "employeePositionFunding")]
        public string EmployeePositionFunding { get; set; }

        /// <summary>
        /// Indicates FERPA training, "Y" for employees who have had FERPA training and "N" for employees who have not.
        /// </summary>
        [DataMember(Name = "employeeIsFerpaTrained")]
        private string EmployeeIsFerpaTrainedString { get; set; }

        /// <summary>
        /// Percentage of an employee's FTE for an incumbent position.
        /// </summary>
        [DataMember(Name = "employeePositionFte")]
        public string EmployeePositionsFTE { get; set; }

        /// <summary>
        /// FTE for the employee as a whole.  Note: this is more complex than just summing the FTE percentages from the incumbent positions.
        /// </summary>
        [DataMember(Name = "employeeFte")]
        public string EmployeeFTE { get; set; }

        /// <summary>
        /// Post Office Box number of an employee's work-related mailing address.
        /// </summary>
        [DataMember(Name = "employeePoBox")]
        public string EmployeePOBox { get; set; }

        /// <summary>
        /// Full name (first name middle initial-or-name last name).
        /// </summary>
        [DataMember(Name = "cn")]
        public string FullName { get; set; }

        /// <summary>
        /// Date of birth in format YYYYMMDD.
        /// </summary>
        [DataMember(Name = "dateOfBirth")]
        public string Birthdate { get; set; }

        /// <summary>
        /// University affiliation.  For information on the use of these attributes, see the EDS eduPersonAffiliation Overview (http://iia.arizona.edu/eds_attributes#edupersonaffiliationoverview).
        /// </summary>
        [DataMember(Name = "eduPersonAffiliation")]
        public IList<string> EduPersonAffiliations { get; set; }

        /// <summary>
        /// Primary University affiliation.  For information on primary affiliation, see EDS eduPersonPrimaryAffiliation Determination (http://iia.arizona.edu/eds_attributes#primaryaffiliationdetermination).
        /// </summary>
        [DataMember(Name = "eduPersonPrimaryAffiliation")]
        public string EduPersonPrimaryAffiliation { get; set; }

        /// <summary>
        /// Eight-digit number that is the primary identifier on campus. The EMPLID is a common identifier that will be shared between UAccess Student and Uaccess Employee.
        /// </summary>
        [DataMember(Name = "emplId")]
        public int EmplId { get; set; }

        /// <summary>
        /// Name of the building that corresponds to an employee's primary department.
        /// </summary>
        [DataMember(Name = "employeeBldgName")]
        public string EmployeeBuildingName { get; set; }

        /// <summary>
        /// Number of the building that corresponds to an employee's primary department.
        /// </summary>
        [DataMember(Name = "employeeBldgNum")]
        public int EmployeeBuildingNumber { get; set; }

        /// <summary>
        /// Contains the text description of a student's career program plan and the format is "Career - Program - Plan" 
        /// </summary>
        [DataMember(Name = "studentAPDesc")]
        public string StudentCareerPlanDescription { get; set; }

        /// <summary>
        /// Contains current and future admit career program plans with these colon (:) delimited items.  For more information, see Career Program Plan (http://iia.arizona.edu/eds_attributes#cpptable).
        /// </summary>
        [DataMember(Name = "studentPrimaryCareerProgramPlan")]
        public string PrimaryStudentCareerProgramPlan { get; set; }

        /// <summary>
        /// If student is, or has previously been, a member of the Honors College, this attribute will be present and reflect their current status in the Honors program. Y indicates "active" and N indicates "inactive".
        /// </summary>
        [DataMember(Name = "studentHonorsActive")]
        public string StudentHonorsActive { get; set; }

        /// <summary>
        /// Contains one or more values representing items of student information not to be released.  For code descriptions, see studentInfoRelease Codes (http://iia.arizona.edu/eds_attributes#employeetype).
        /// </summary>
        [DataMember(Name = "studentInfoReleaseCode")]
        public IList<string> InformationReleaseCodes { get; set; }

        /// <summary>
        /// Contains past values of the studentStatus attribute.
        /// </summary>
        [DataMember(Name = "studentStatusHistory")]
        public IList<string> StudentStatusHistory { get; set; }

        /// <summary>
        /// Person's preferred given name (first name and middle initial-or-name).
        /// </summary>
        [DataMember(Name = "preferredGivenname")]
        public string PreferredFirstMiddleName { get; set; }

        /// <summary>
        /// Dept # of employee's primary department (also known as home department); refers to the department where an employee's paycheck is sent.
        /// </summary>
        [DataMember(Name = "employeePrimaryDept")]
        public string EmployeePrimaryDepartment { get; set; }

        /// <summary>
        /// Textual description corresponding to employeePrimaryDept.
        /// </summary>
        [DataMember(Name = "employeePrimaryDeptName")]
        public string EmployeePrimaryDepartmentName { get; set; }

        /// <summary>
        /// UAccess Employee status codes.  For code descriptions, see employeeStatus Codes (http://iia.arizona.edu/eds_attributes#employeestatus).
        /// </summary>
        [DataMember(Name = "employeeStatus")]
        public string EmployeeStatus { get; set; }

        /// <summary>
        /// One-character code from UAccess Employee that identifies  the type of an employment.  For type descriptions, see employeeType Descriptions (http://iia.arizona.edu/eds_attributes#employeetype).
        /// </summary>
        [DataMember(Name = "employeeType")]
        public string EmployeeType { get; set; }

        /// <summary>
        /// First name and middle initial-or-name.
        /// </summary>
        [DataMember(Name = "givenName")]
        public string FirstMiddleName { get; set; }

        /// <summary>
        /// UA email address.
        /// </summary>
        [DataMember(Name = "mail")]
        public string Email { get; set; }

        /// <summary>
        /// Primary action date for a DCC and the start date for new DCCs. it can be a future date, in which case the dccStatus will be 'F'.
        /// </summary>
        [DataMember(Name = "dccPrimaryActionDate")]
        public string DccPrimaryActionDate { get; set; }

        /// <summary>
        /// Primary department code for a DCC.
        /// </summary>
        [DataMember(Name = "dccPrimaryDept")]
        public string DccPrimaryDepartment { get; set; }

        /// <summary>
        /// Primary department name for a DCC.
        /// </summary>
        [DataMember(Name = "dccPrimaryDeptName")]
        public string DccPrimaryDepartmentName { get; set; }

        /// <summary>
        /// Primary end date for the DCC relationship.
        /// </summary>
        [DataMember(Name = "dccPrimaryEndDate")]
        public string DccPrimaryEndDate { get; set; }

        /// <summary>
        /// Primary status of the DCC.  For status values, see dccPrimaryStatus Values (http://iia.arizona.edu/eds_attributes#dccprimarystatus).
        /// </summary>
        [DataMember(Name = "dccPrimaryStatus")]
        public string DccPrimaryStatus { get; set; }

        /// <summary>
        /// Primary title of the DCC.
        /// </summary>
        [DataMember(Name = "dccPrimaryTitle")]
        public string DccPrimaryTitle { get; set; }

        /// <summary>
        /// Primary type of the DCC.  For DCC type values, see the DCC Types Table (http://iia.arizona.edu/eds_attributes#dcctypes).
        /// </summary>
        [DataMember(Name = "dccPrimaryType")]
        public string DccPrimaryType { get; set; }

        /// <summary>
        /// The subcategory code for the primary DCC relationship, if (and only if) the primary DCC relationship type has a subcategory (else the attribute will not be present).  For DCC type values, see the DCC Types Table (http://iia.arizona.edu/eds_attributes#dcctypes).
        /// </summary>
        [DataMember(Name = "dccPrimarySubCategory")]
        public string DccPrimarySubCategory { get; set; }

        /// <summary>
        ///A DCC's relationship(s) with the University representated as a colon (:) separated list consisting of the DCC's title, type, department, department name, status, action date, end date, and subcategory code (if any).  For DCC type values, see the DCC Types Table (http://iia.arizona.edu/eds_attributes#dcctypes).
        /// </summary>
        [DataMember(Name = "dccRelation")]
        public IList<string> DccRelations { get; set; }

        /// <summary>
        /// UAID of a DSV that has converted to a DCC.
        /// </summary>
        [DataMember(Name = "dsvUAID")]
        public string DsvUaId { get; set; }

        /// <summary>
        /// LDAP object classes identify the type of a directory entry. Object classes define the mandatory and optional attributes an entry of a specific type may carry.
        /// </summary>
        [DataMember(Name = "objectClass")]
        public IList<string> ObjectClasses { get; set; }

        /// <summary>
        ///  Last name.
        /// </summary>
        [DataMember(Name = "sn")]
        public string LastName { get; set; }

        /// <summary>
        /// Uniquely identifies each UA-affiliated person.
        /// </summary>
        [DataMember(Name = "uaid")]
        public string UniversityId { get; set; }

        /// <summary>
        /// Each value is the DN of a group the person is a member of.  For more information, see Course Groups (http://iia.arizona.edu/coursegroups).
        /// </summary>
        [DataMember(Name = "isMemberOf")]
        public IList<string> Memberships { get; set; }

        /// <summary>
        /// Employee's work address city.
        /// </summary>
        [DataMember(Name = "employeeCity")]
        public string EmployeeCity { get; set; }

        /// <summary>
        /// Employee's work address zip code.
        /// </summary>
        [DataMember(Name = "employeeZip")]
        public string EmployeePostalCode { get; set; }

        /// <summary>
        /// Alternate employee title.
        /// </summary>
        [DataMember(Name = "employeeAlternateTitle")]
        public string EmployeeAlternateTitle { get; set; }

        /// <summary>
        /// Domain name?
        /// </summary>
        [DataMember(Name = "dn")]
        public string DomainName { get; set; }        
    }
}
