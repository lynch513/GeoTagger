using Microsoft.EntityFrameworkCore;

namespace GeoTagger.Models
{
    [Owned]
    public class GeoCoord
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
