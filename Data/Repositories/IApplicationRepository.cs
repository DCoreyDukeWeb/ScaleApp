using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCoreyDuke.CodeBase.Interfaces;
using DCoreyDuke.CodeBase.Abstracts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Data.DBContext;

namespace Data.Repositories
{
    public interface IApplicationRepository : IRepository<Application>
    {
    }

    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {

        public ApplicationRepository(DataContext context) : base(context)
        {

        }


    }




}
