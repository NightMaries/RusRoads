using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RusRoads.API.Entities
{
    public class workingCalendar
    {
        public int Id {get;set;}
        public DateTime ExceptionDate {get;set;}
        public bool IsWorkingDay {get;set;}
    }
}