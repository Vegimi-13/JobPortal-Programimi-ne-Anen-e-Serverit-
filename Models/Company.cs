using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Industry { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }
    }
}
