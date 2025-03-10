using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RusRoads.API.Entity
{
    public class Comment : Base
    {
        public int DocumentId { get; set; }
        public Document? Document { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateCreated = DateTime.UtcNow;
        public DateTime DateUpdated = DateTime.UtcNow;
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Employee? Author { get; set; }
    }

    public record CommentDto
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string Text { get; set; } = string.Empty;
        public string DateCreated = DateTime.UtcNow.ToString();
        public string DateUpdated = DateTime.UtcNow.ToString();
        public AuthorDto? Author { get; set; }
    }
    public record AuthorDto(string Name, string Position);

}    
