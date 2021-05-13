using Data.BaseClasses;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Review : BaseEntity
    {
        [Required]
        public string Description { get; set; }

        public Member Creator { get; set; }

        public Guid? CreatorId { get; set; }

        public Member Recipient { get; set; }
        
        public Guid? RecipientId { get; set; }
    }
}