using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GeoTagger.Models
{
    [Owned]
    public class GeoObject
    {
        [Required]
        public GeoType Type { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        public bool? Prefix { get; set; }

        public override string ToString() =>
            (Prefix != null && Prefix == true) ? string.Concat(Type, " ", Name) : string.Concat(Name, " ", Type);
    }

}
