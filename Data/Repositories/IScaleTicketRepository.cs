using DCoreyDuke.CodeBase.Abstracts;
using ScaleApp.Data.DBContext;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.Repositories
{
    public interface IScaleTicketRepository
    {
    }

     public class ScaleTicketRepository(DataContext context) : Repository<ScaleTicket>(context), IScaleTicketRepository
    {
    }

}