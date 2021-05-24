using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GeoTagger.Models
{
    [Owned]
    public class GeoObject
    {
        [Required]
        public GeoType Type { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Prefix { get; set; }

        public override string ToString() =>
            Prefix ? string.Concat(Type, " ", Name) : string.Concat(Name, " ", Type);
    }

}
