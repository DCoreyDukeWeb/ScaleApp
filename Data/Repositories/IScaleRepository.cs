using Data.DBContext;
using Data.Entities;
using DCoreyDuke.CodeBase.Abstracts;

namespace Data.Repositories
{
    public interface IScaleRepository
    {
    }

   public class ScaleRepository : Repository<Scale>, IScaleRepository
    {

        public ScaleRepository(DataContext context) : base(context)
        {

        }


    }

    
}