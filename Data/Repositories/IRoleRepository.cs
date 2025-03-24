using DCoreyDuke.CodeBase.Abstracts;
using ScaleApp.Data.DBContext;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.Repositories
{
    public interface IRoleRepository
    {
    }

     public class RoleRepository(DataContext context) : Repository<Role>(context), IRoleRepository
    {
    }

}