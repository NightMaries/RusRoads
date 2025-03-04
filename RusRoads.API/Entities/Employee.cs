using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RusRoads.API.Entity
{
    public class Employee : Base
    {
        public required string FIO { get; set; }
        [MaxLength(20)]
        public string? PersonalPhone { get; set; } = string.Empty;
        public DateTime DateBorn { get; set; }
        public required int SubdivisionId { get; set; }
        public Subdivision? Subdivision { get; set; }

        public required string Cabinet { get; set; }
        public required string Position { get; set; }
        public int? LeaderId { get; set; } = null;
        [ForeignKey("LeaderId")]
        public Employee? Leader { get; set; }


        public int? HelperId { get; set; } = null;
        [ForeignKey("HelperId")]
        public Employee? Helper { get; set; }

        [MaxLength(20)]
        public required string JobNumber { get; set; }

        public required string Email { get; set; }
        public string? AdditionalInfo { get; set; } = string.Empty;
        public IEnumerable<Event>? Events { get; set; }
        public DateTime? DismissDate { get; set; } = null;
    }
}