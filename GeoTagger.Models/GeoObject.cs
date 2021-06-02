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
            (Prefix, Type.Reduction) switch
            {
                (true, null) => string.Concat(Type, " ", Name),
                (false, null) => string.Concat(Name, " ", Type),
                (_, not null) => string.Concat(Type, ".", Name)
            };
            // Prefix ? string.Concat(Type, " ", Name) : string.Concat(Name, " ", Type);
    }

}
