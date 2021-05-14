using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.BaseClasses;

namespace Data
{
    public class Member : BaseEntity
    {
        public Member()
        {
            Advertisements = new HashSet<Advertisement>();
            MemberLanguage = new HashSet<MemberLanguage>();
            MemberLocation = new HashSet<MemberLocation>();
            CreatedReviews = new HashSet<Review>();
            ReceivedReviews = new HashSet<Review>();
        }

        [Required]
        [StringLength(50)]
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
        
        [Required]
        public DateTime CreatedAt { get; set; }
        
        public DateTime? DeletedAt { get; set; }
        
        [Required]
        public DateTime LastVisitDate { get; set; }
        
        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<MemberLanguage> MemberLanguage { get; set; }
        public virtual ICollection<MemberLocation> MemberLocation { get; set; }
        public virtual ICollection<Review> CreatedReviews { get; set; }
        public virtual ICollection<Review> ReceivedReviews { get; set; }
    }
}
