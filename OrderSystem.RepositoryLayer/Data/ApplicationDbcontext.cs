using Microsoft.EntityFrameworkCore;
using OrderSystem.CoreLayer.Entites;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.RepositoryLayer.Data
{
    public class ApplicationDbcontext:DbContext
    {

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> dbContext):base(dbContext)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
    }
}
