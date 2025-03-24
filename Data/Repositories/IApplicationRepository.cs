using DCoreyDuke.CodeBase.Abstracts;
using DCoreyDuke.CodeBase.Interfaces;
using ScaleApp.Data.DBContext;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.Repositories
{
    public interface IApplicationRepository : IRepository<Application>
    {
    }

    public class ApplicationRepository(DataContext context) : Repository<Application>(context), IApplicationRepository
    {
    }




}
