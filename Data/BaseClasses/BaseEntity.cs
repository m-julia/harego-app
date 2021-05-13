using System;
using System.ComponentModel.DataAnnotations;

namespace Data.BaseClasses
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
