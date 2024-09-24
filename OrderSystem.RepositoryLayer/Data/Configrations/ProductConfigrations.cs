using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderSystem.CoreLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.RepositoryLayer.Data.Configrations
{
    internal class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> P)
        {
            P.Property(p => p.Name)
                .IsRequired();


            P.Property(p => p.Price)
                .IsRequired();  

            P.Property(p => p.Stock)
                .IsRequired();

        }
    }
}
