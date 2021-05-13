using Data.BaseClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Language : BaseEntity
    {
        public Language()
        {
            MemberLanguage = new HashSet<MemberLanguage>();
        }

        [Required]
        public string LanguageName { get; set; }
        public virtual ICollection<MemberLanguage> MemberLanguage { get; set; }
    }
}