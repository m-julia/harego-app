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

        public override Advertisement Update(Guid id, Advertisement entity)
        {
            var advertisement = context.Advertisements.FirstOrDefault(a => a.Id == id);

            advertisement.Description = entity.Description;
            advertisement.FromLocation = entity.FromLocation;
            advertisement.ToLocation = entity.ToLocation;
            advertisement.TripDate = entity.TripDate;
            advertisement.Weight = entity.Weight;
            advertisement.Price = entity.Price;
            advertisement.IsCompleted = entity.IsCompleted;

            return base.Update(id, advertisement);
        }
    }
}
