using System;

namespace Data
{
    public class MemberLocation
    {
        public Member Member { get; set; }
        public Guid MemberId { get; set; }
        public Location Location { get; set; }
        public Guid LocationId { get; set; }
    }
}