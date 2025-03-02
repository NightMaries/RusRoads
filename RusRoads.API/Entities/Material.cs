using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace RusRoads.API.Entity
{
    public class Material:Base
    {
        public string Name {get;set;} = string.Empty;
        public DateTime DateApproval {get;set;}
        public DateTime DateUpdate {get;set;}
        public string Status {get;set;} = string.Empty;
        public string Type {get;set;} = string.Empty;
        public string Region {get;set;} = string.Empty;
        public int AuthorId {get;set;}
        [ForeignKey("AuthorId")]
        public Employee? Author {get;set;}

    }
}