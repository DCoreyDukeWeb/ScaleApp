using DCoreyDuke.CodeBase.Abstracts;
using ScaleApp.Data.DBContext;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.Repositories
{
    public interface IPermissionRepository
    {
    }

   

     public class PermissionRepository(DataContext context) : Repository<Permission>(context), IPermissionRepository
    {
    }




}