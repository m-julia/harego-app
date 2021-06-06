using Data;
using System;
using System.ComponentModel.DataAnnotations;


namespace API.DTO
{
    public class MemberDto
    {
        [Required]
        [StringLength(70)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(70)]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string Token { get; set; }

        public string Image { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        [Required]
        public DateTime LastVisitDate { get; set; }
    }
}
