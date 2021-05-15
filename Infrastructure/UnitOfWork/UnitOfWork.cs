using Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        private IRepository<Member> memberRepository;
        public IRepository<Member> MemberRepository
        {
            get
            {
                if (memberRepository == null)
                {
                    memberRepository = new MemberRepository(_context);
                }

                return memberRepository;
            }
        }

        private IRepository<Advertisement> advertisementRepository;
        public IRepository<Advertisement> AdvertisementRepository
        {
            get
            {
                if (advertisementRepository == null)
                {
                    advertisementRepository = new AdvertisementRepository(_context);
                }
                return advertisementRepository;
            }
        }
    
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
