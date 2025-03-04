using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RusRoads.API.Entity
{
    public class Messuare:Base
    {
        public string Name {get;set;} = string.Empty;
        public int MessuareTypeId {get;set;}
        public MessuareType? MessuareType {get;set;}
        public string Status {get;set;}  =string.Empty;

        public DateTime DateStart {get;set;}
        public DateTime DateEnd {get;set;}
        public string ResponsiblePerson {get;set;} = string.Empty;
        public string Description {get;set;}= string.Empty;  
        
        public int? MaterialId {get;set;}
        public  Material? Material {get;set;}
        
        public int? AuthorId {get;set;}
        [ForeignKey ("AuthorId")]
        public Employee? Author {get;set;}
        public IEnumerable<Subdivision>? Subdivisions {get;set;}

    }
}