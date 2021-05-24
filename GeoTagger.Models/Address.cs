using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeoTagger.Models
{
    [Owned]
    public class Address
    {
        [Required]
        public string Country { get; set; }

        public GeoObject State { get; set; }

        [Required]
        public GeoObject City { get; set; }

        [Required]
        public GeoObject Street { get; set; }

        [Required]
        public GeoObject House { get; set; }

        public GeoObject Block { get; set; }

        public GeoObject Room { get; set; }

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
