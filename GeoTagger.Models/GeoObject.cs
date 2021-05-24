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

        [Required]
        public bool Prefix { get; set; } = true;

        public override string ToString() =>
            Prefix ? string.Concat(Type, " ", Name) : string.Concat(Name, " ", Type);
    }

}
