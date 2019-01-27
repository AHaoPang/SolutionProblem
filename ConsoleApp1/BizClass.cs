using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class BizClass
    {
        public _Id _id { get; set; }
        public Oidshift OIdShift { get; set; }
        public Attendanceplanoid AttendancePlanOId { get; set; }
        public Attendanceorg AttendanceOrg { get; set; }
        public Jobtype JobType { get; set; }
        public Userids UserIds { get; set; }
        public Type Type { get; set; }
        public Startdate StartDate { get; set; }
        public Stopdate StopDate { get; set; }
        public B5dec8beFaf24051Ae13886Dfb2a88c1Oidorganization b5dec8befaf24051ae13886dfb2a88c1OIdOrganization { get; set; }
        public B5dec8beFaf24051Ae13886Dfb2a88c1Oiddepartment b5dec8befaf24051ae13886dfb2a88c1OIdDepartment { get; set; }
        public B5dec8beFaf24051Ae13886Dfb2a88c1Employmenttype b5dec8befaf24051ae13886dfb2a88c1EmploymentType { get; set; }
        public B5dec8beFaf24051Ae13886Dfb2a88c1Employeestatus b5dec8befaf24051ae13886dfb2a88c1EmployeeStatus { get; set; }
        public B5dec8beFaf24051Ae13886Dfb2a88c1Oidjobpost b5dec8befaf24051ae13886dfb2a88c1OIdJobPost { get; set; }
        public B5dec8beFaf24051Ae13886Dfb2a88c1Entrydate b5dec8befaf24051ae13886dfb2a88c1EntryDate { get; set; }

        [Newtonsoft.Json.JsonProperty("b5dec8be-faf2-4051-ae13-886dfb2a88c1~LastWorkDate")]
        public B5dec8beFaf24051Ae13886Dfb2a88c1Lastworkdate b5dec8befaf24051ae13886dfb2a88c1LastWorkDate { get; set; }
        public B5dec8beFaf24051Ae13886Dfb2a88c1Place b5dec8befaf24051ae13886dfb2a88c1Place { get; set; }
        public Objectdataaction ObjectDataAction { get; set; }
        public Leavedate LeaveDate { get; set; }
        public Transferdate TransferDate { get; set; }
        public Oidgroup OIdGroup { get; set; }
        public Oidcalendar OIdCalendar { get; set; }
    }

    public class _Id
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class Oidshift
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class Attendanceplanoid
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class Attendanceorg
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class Jobtype
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class Userids
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
        public Avatars avatars { get; set; }
    }

    public class Avatars
    {
        public _119897230 _119897230 { get; set; }
    }

    public class _119897230
    {
        public bool hasAvatar { get; set; }
        public string color { get; set; }
    }

    public class Type
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class Startdate
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class Stopdate
    {
        public object name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class B5dec8beFaf24051Ae13886Dfb2a88c1Oidorganization
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class B5dec8beFaf24051Ae13886Dfb2a88c1Oiddepartment
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class B5dec8beFaf24051Ae13886Dfb2a88c1Employmenttype
    {
        public string name { get; set; }
        public object text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class B5dec8beFaf24051Ae13886Dfb2a88c1Employeestatus
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class B5dec8beFaf24051Ae13886Dfb2a88c1Oidjobpost
    {
        public string name { get; set; }
        public object text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class B5dec8beFaf24051Ae13886Dfb2a88c1Entrydate
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class B5dec8beFaf24051Ae13886Dfb2a88c1Lastworkdate
    {
        public string name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class B5dec8beFaf24051Ae13886Dfb2a88c1Place
    {
        public string name { get; set; }
        public object text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class Objectdataaction
    {
        public string name { get; set; }
        public object text { get; set; }
        public string num { get; set; }
        public string value { get; set; }
    }

    public class Leavedate
    {
        public object name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public object value { get; set; }
    }

    public class Transferdate
    {
        public object name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public object value { get; set; }
    }

    public class Oidgroup
    {
        public object name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public object value { get; set; }
    }

    public class Oidcalendar
    {
        public object name { get; set; }
        public string text { get; set; }
        public string num { get; set; }
        public object value { get; set; }
    }


}
