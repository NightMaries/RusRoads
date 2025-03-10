using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RusRoads.API.Entity
{
    public class User:Base
    {
        public required string Name {get;set;}
        public required string Password {get;set;}
        public int EmployeeId {get;set;}
        public Employee? Employee {get;set;}
                
    }
    public record UserDto(string Name, string Password);
}