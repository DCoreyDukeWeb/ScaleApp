using DCoreyDuke.CodeBase.Abstracts;
using ScaleApp.Data.DBContext;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.Repositories
{
    public interface ICustomerRepository
    {
    }

    public class CustomerRepository(DataContext context) : Repository<Customer>(context), ICustomerRepository
    {
    }

}