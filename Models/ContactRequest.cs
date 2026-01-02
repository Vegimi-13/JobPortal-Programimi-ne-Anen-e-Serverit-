using System;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class ContactRequest
    {
        public int Id { get; set; }

        [Required]
        public int DeveloperProfileId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;

        // Navigation properties
        public DeveloperProfile DeveloperProfile { get; set; }
        public Company Company { get; set; }
    }
}
