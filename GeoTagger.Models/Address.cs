using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeoTagger.Models
{
    [Owned]
    public class Address
    {
        [Display(Name = "Страна")]
        [Required]
        public string Country { get; set; } = null!;

        [Display(Name = "Область")]
        public GeoObject? State { get; set; }

        [Display(Name = "Город")]
        [Required]
        public GeoObject City { get; set; } = null!;

        [Display(Name = "Улица")]
        [Required]
        public GeoObject Street { get; set; } = null!;

        [Display(Name = "Дом")]
        [Required]
        public GeoObject House { get; set; } = null!;

        [Display(Name = "Корпус")]
        public GeoObject? Block { get; set; } 

        [Display(Name = "Помещение")]
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
