using Data.BaseClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Location : BaseEntity
    {
        public Location()
        {
            MemberLocation = new HashSet<MemberLocation>();
        }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public string CityName { get; set; }

        public virtual ICollection<MemberLocation> MemberLocation { get; set; }
    }
}