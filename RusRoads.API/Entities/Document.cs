using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace RusRoads.API.Entity
{
    public class Document:Base
    {
        public string Title {get;set;} = string.Empty;
        public DateTime DateCreated {get;set;} = DateTime.UtcNow;
    
        public DateTime DateUpdated {get;set;} = DateTime.UtcNow;
        public string Category {get;set;} = string.Empty;
        public bool HasComments {get;set;}
        public IEnumerable<Comment>? Comments {get;set;}
    }
}