using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeoTagger.Models
{
    [Owned]
    public class Address
    {
        [Required]
        public string Country { get; set; } = null!;

        public GeoObject? State { get; set; }

        [Required]
        public GeoObject City { get; set; } = null!;

        [Required]
        public GeoObject Street { get; set; } = null!;

        [Required]
        public GeoObject House { get; set; } = null!;

        public GeoObject? Block { get; set; } 

        public GeoObject? Room { get; set; } 

        public override string ToString()
        {
            var result = new StringBuilder(string.Concat(Street, ", ", House));
            if (Block != null)
                result.AppendFormat(" {0}", Block);
            if (Room != null)
                result.AppendFormat(" {0}", Room);
            return result.ToString();
        }
    }
}
