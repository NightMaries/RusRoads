using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RusRoads.API.DTO
{
    public class SubdivisionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int LeaderSubdivisionId { get; set; }
    }
}