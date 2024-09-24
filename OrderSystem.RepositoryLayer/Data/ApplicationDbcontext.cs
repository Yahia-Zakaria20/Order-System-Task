using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.RepositoryLayer.Data
{
    public class ApplicationDbcontext:DbContext
    {

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> dbContext):base(dbContext)
        {
            
        }
    }
}
