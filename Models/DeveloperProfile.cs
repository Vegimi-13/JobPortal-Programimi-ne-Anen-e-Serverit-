using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class DeveloperProfile
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Skills { get; set; }

        public int YearsOfExperience { get; set; }

        public string Location { get; set; }

        public bool OpenToWork { get; set; }
    }
}
