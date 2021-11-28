 using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.ImgUri)
                .IsRequired(true)
                .HasMaxLength(200);

            builder.Property(ci => ci.Price)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");

            builder.Property(ci => ci.Description)
                .IsRequired(false)
                .HasMaxLength(1_000);

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Price = 10,
                    ImgUri = "http://ahoj.ahoj/1",
                    Description = "ahoj1 je dobry",
                    Name = "ahoj1"
                },
                new Product
                {
                    Id = 2,
                    Price = 20,
                    ImgUri = "http://ahoj.ahoj/2",
                    Description = "ahoj2 je dobry",
                    Name = "ahoj2"
                },
                new Product
                {
                    Id = 3,
                    Price = 30,
                    ImgUri = "http://ahoj.ahoj/3",
                    Description = "ahoj3 je dobry",
                    Name = "ahoj3"
                });
        }
    }
}
