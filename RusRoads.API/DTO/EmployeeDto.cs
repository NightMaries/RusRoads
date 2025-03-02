using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RusRoads.API.Entity;

namespace RusRoads.API.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FIO { get; set; } 
        public string PersonalPhone { get; set; } 
        public DateTime DateBorn { get; set; }
        public int SubdivisionId { get; set; }
        public SubdivisionDto? Subdivision { get; set; }

        public string Position { get; set; }
        public int? LeaderId { get; set; } = null;
        public int? HelperId { get; set; } = null;
        public string JobNumber { get; set; } 
        public string Email { get; set; } 
        public string Cabinet { get; set; } 
        public string? AdditionalInfo { get; set; } 

        public DateTime? DismissDate { get; set; } = null;

    }
}