using DCoreyDuke.CodeBase.Abstracts;
using ScaleApp.Data.DBContext;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.Repositories
{
    public interface IContactRepository
    {
    }

    public class ContactRepository(DataContext context) : Repository<Contact>(context), IContactRepository
    {
    }
}