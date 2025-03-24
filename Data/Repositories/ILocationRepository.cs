using DCoreyDuke.CodeBase.Abstracts;
using ScaleApp.Data.DBContext;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.Repositories
{
    public interface ILocationRepository
    {
    }
    
    public class LocationRepository(DataContext context) : Repository<Location>(context), ILocationRepository
    {
    }
}