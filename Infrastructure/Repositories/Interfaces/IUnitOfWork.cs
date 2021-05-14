using Data;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Member> MemberRepository { get; }
        IRepository<Advertisement> AdvertisementRepository { get; }
        void SaveChanges();
    }
}
