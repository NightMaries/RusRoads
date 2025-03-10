using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RusRoads.API.Entity
{
    public class Subdivision:Base
    {
        public string Name {get;set;} = string.Empty;
        public string? Description {get;set;} = string.Empty;
        public IEnumerable<Employee>? Employees {get;set;}        

        public int? LeaderSubdivisionId {get;set;}
        public Subdivision? LeaderSubdivision {get;set;}
        public int? MessuareId {get;set;}
        public Messuare? Messuare {get;set;}
    }
}