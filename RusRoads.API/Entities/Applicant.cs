using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RusRoads.API.Entity
{
    public class Applicant:Base
    {
        public string FIO {get;set;} = string.Empty;
        public byte[]? File {get;set;}
        public string DirectedActivity {get;set;} = string.Empty;
        public DateTime DateAdmission {get;set;}
        public IEnumerable<Event>? Events {get;set;}
    }
}