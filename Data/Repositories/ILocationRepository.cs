using Data.DBContext;
using Data.Entities;
using DCoreyDuke.CodeBase.Abstracts;

namespace Data.Repositories
{
    public interface ILocationRepository
    {
    }
    
    public class LocationRepository : Repository<Location>, ILocationRepository
    {

        public LocationRepository(DataContext context) : base(context)
        {

        }


    }
}