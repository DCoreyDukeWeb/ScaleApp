using Data.DBContext;
using Data.Entities;
using DCoreyDuke.CodeBase.Abstracts;

namespace Data.Repositories
{
    public interface IRoleRepository
    {
    }

     public class RoleRepository : Repository<Role>, IRoleRepository
    {

        public RoleRepository(DataContext context) : base(context)
        {

        }


    }
    
}