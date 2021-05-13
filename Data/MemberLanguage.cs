using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class MemberLanguage
    {
        public Member Member { get; set; }

        public Guid MemberId { get; set; }

        public Language Language { get; set; }

        public Guid LanguageId { get; set; }
    }
}