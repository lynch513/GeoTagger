using System;
using System.ComponentModel.DataAnnotations;

namespace GeoTagger.Models
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; } 

        [Required]
        public string Name { get; set; } = null!;

        public string? Subtitle { get; set; }

        public string? Description { get; set; }

        public Address? Address { get; set; }

        [Required]
        public GeoCoord Coord { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public Tag()
        {
            Coord = new GeoCoord();
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }

        public override string ToString() =>
            Name;
    }
}
