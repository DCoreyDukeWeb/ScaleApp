using Data.DBContext;
using Data.Entities;
using DCoreyDuke.CodeBase.Abstracts;

namespace Data.Repositories
{
    public interface IScaleTicketRepository
    {
    }

     public class ScaleTicketRepository : Repository<ScaleTicket>, IScaleTicketRepository
    {

        public ScaleTicketRepository(DataContext context) : base(context)
        {

        }


    }
    
}