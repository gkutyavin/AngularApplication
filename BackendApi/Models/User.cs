using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApi.Models
{
    public class User
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool Agree { get; set; }

        [Required]
        public int CountryID { get; set; }

        [Required]
        public int ProvinceID { get; set; }

        [ForeignKey("CountryID")]
        public Country Country { get; set; }

        [ForeignKey("ProvinceID")]
        public Province Province { get; set; }
    }
}
