using Data.DBContext;
using Data.Entities;
using DCoreyDuke.CodeBase.Abstracts;

namespace Data.Repositories
{
    public interface IPermissionRepository
    {
    }

   

     public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {

        public PermissionRepository(DataContext context) : base(context)
        {

        }


    }

   

    
}