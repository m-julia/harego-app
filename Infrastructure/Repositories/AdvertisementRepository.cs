using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    class AdvertisementRepository : GenericRepository<Advertisement>
    {
        public AdvertisementRepository(DataContext context) : base(context)
        {}

        public override Advertisement Update(Advertisement entity)
        {
            var advertisement = context.Advertisements.FirstOrDefault(a => a.Id == entity.Id);

            advertisement.Description = entity.Description;
            advertisement.FromLocation = entity.FromLocation;
            advertisement.ToLocation = entity.ToLocation;
            advertisement.FromLocation = entity.FromLocation;
            advertisement.IsCompleted = entity.IsCompleted;

            return base.Update(advertisement);
        }
    }
}
