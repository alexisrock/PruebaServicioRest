using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PruebaServiceDBContext : DbContext
    {
        public PruebaServiceDBContext(DbContextOptions<PruebaServiceDBContext> options) : base(options) { }


        public virtual DbSet<Producto> SpSelectAllProducts { get; set; }
        public virtual DbSet<Producto> SpSelectIdProducts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Producto>().HasNoKey().ToView("SpSelectAllProducts");
            modelBuilder.Entity<Producto>().HasNoKey().ToView("SpSelectIdProducts");

        }
    }

}

