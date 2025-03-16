using Data.DBContext;
using Data.Entities;
using DCoreyDuke.CodeBase.Abstracts;

namespace Data.Repositories
{
    public interface IUserRepository
    {
    }
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(DataContext context) : base(context)
        {

        }


    }
}