using System;
using System.ComponentModel.DataAnnotations;

namespace GeoTagger.Models
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; } 

        [Display(Name = "Имя")]
        [Required]
        public string Name { get; set; } = null!;

        [Display(Name = "Прим")]
        public string? Subtitle { get; set; }

        [Display(Name = "Инфо")]
        public string? Description { get; set; }

        [Display(Name = "Адрес")]
        public Address? Address { get; set; }

        [Display(Name = "Координаты")]
        [Required]
        public GeoCoord Coord { get; set; }

        [Display(Name = "Создан")]
        public DateTime Created { get; set; }

        [Display(Name = "Обновлен")]
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
