using Data.BaseClasses;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Advertisement : BaseEntity
    {
        [Required]
        public string FromLocation { get; set; }

        [Required]
        public string ToLocation { get; set; }

        [Required]
        public DateTime TripDate { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        public string Description { get; set; }

        public Member Member { get; set; }

        public Guid MemberId { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }
        
        public bool? IsCompleted { get; set; }
    }
}