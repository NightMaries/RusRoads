using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RusRoads.API.Entity
{
    public class EventType:Base
    {
        public string Name {get;set; } = string.Empty;
        public IEnumerable<Event>? Events {get;set;}
    }
}