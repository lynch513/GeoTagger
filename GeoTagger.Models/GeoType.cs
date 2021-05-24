using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GeoTagger.Models
{
    [Owned]
    public class GeoType
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Reduction { get; set; }

        public override string ToString() =>
            string.IsNullOrEmpty(Reduction) ? Name : Reduction;
    }

}
