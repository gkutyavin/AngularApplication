using System.ComponentModel.DataAnnotations;

namespace BackendApi.Models
{
    public class Country
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ICollection<Province> Provinces { get; set; }
    }
}