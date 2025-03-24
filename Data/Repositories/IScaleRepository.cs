using DCoreyDuke.CodeBase.Abstracts;
using ScaleApp.Data.DBContext;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.Repositories
{
    public interface IScaleRepository
    {
    }

   public class ScaleRepository(DataContext context) : Repository<Scale>(context), IScaleRepository
    {
    }


}