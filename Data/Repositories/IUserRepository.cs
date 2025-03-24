using DCoreyDuke.CodeBase.Abstracts;
using ScaleApp.Data.DBContext;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.Repositories
{
    public interface IUserRepository
    {
    }
    public class UserRepository(DataContext context) : Repository<User>(context), IUserRepository
    {
    }
}