using Data.DBContext;
using Data.Entities;
using DCoreyDuke.CodeBase.Abstracts;

namespace Data.Repositories
{
    public interface IContactRepository
    {
    }

    public class ContactRepository : Repository<Contact>, IContactRepository
    {

        public ContactRepository(DataContext context) : base(context)
        {

        }


    }
}