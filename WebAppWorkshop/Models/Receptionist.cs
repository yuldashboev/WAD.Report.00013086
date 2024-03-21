using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppWorkshop.Models
{
    public class Receptionist
    {
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string? phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? email { get; set; }

    }
}
