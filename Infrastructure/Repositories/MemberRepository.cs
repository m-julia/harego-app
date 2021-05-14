using Data;
using System;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MemberRepository : GenericRepository<Member>
    {
        public MemberRepository(DataContext context) : base(context)
        {

        }

        public override Member Update(Member entity)
        {
            var member = context.Members.FirstOrDefault(m => m.Id == entity.Id);
            
            if (member == null)
            {
                return null;
            } 

            member.FirstName = entity.FirstName;
            member.LastName = entity.LastName;
            member.Birthday = entity.Birthday;
            member.PhoneNumber = entity.PhoneNumber;
            member.Email = entity.Email;
                                    
            return base.Update(member);
        }

        public Member UpdateLastVisitDate(Member entity)
        {
            var member = context.Members.FirstOrDefault(m => m.Id == entity.Id);
            
            if (member == null)
            {
                return null;
            }

            member.LastVisitDate = DateTime.Now;

            return base.Update(member);
        }
    }
}
