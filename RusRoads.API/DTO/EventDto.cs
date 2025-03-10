using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RusRoads.API.Entity;

namespace RusRoads.API.DTO
{
    public class EventDto
    {
        public int Id {get;set;}
        public DateTime DateStart {get;set;}
        public DateTime DateEnd {get;set;}
        public int EventTypeId {get;set;}
        public string Description {get;set;} = string.Empty;
        public int EmployeeId {get;set;}
    }
}