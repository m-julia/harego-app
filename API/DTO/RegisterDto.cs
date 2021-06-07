using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class RegisterDto
    {
        [Required]
        [StringLength(70)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(70)]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

    }
}
