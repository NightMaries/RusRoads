using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RusRoads.API.Entity
{
    public class Event:Base
    {
        public DateTime DateStart {get;set;}
        public DateTime DateEnd {get;set;}
        public int EventTypeId {get;set;}
        public EventType? EventType {get;set;}

        public int EmployeeId {get;set;}
        public Employee? Employee {get;set;}
        public int? ApplicantId {get;set;}
        public Applicant? Applicant {get;set;}
        public string Description {get;set;} = string.Empty;

    }
}