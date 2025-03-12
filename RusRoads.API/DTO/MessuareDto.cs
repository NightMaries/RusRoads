using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RusRoads.API.DTO
{
    public class MessuareDto
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public DateTime DateStart {get;set;}
        public DateTime DateEnd {get;set;}
        public DateTime DateCreated {get;set;}
        public required string Region {get;set;}
        public string ResponsiblePerson {get;set;} = string.Empty;
        public string Description {get;set;}= string.Empty;  
    }
}