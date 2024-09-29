using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Data
{
    internal class ApplicartionDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = CRUD; Trusted_Connection = True; TrustServerCertificate = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(P => {
                P.Property(P => P.Name).HasColumnType("varchar(20)");
                P.Property(P => P.Price).HasColumnType("decimal(12,2)");
            });

            modelBuilder.Entity<Order>(P => {
                P.Property(P => P.Address).HasColumnType("varchar(50)");
            });

        }

        public DbSet <Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
