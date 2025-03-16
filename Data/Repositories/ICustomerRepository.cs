using Data.DBContext;
using Data.Entities;
using DCoreyDuke.CodeBase.Abstracts;

namespace Data.Repositories
{
    public interface ICustomerRepository
    {
    }

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        public CustomerRepository(DataContext context) : base(context)
        {

        }


    }
    
}