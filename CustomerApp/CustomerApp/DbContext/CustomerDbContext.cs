using CustomerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.DbContextCustomer
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public CustomerDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // we can either add the data annotations here or on the model class
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().Ignore(c => c.guid);

            // here, mapping to database table is done.
            modelBuilder.Entity<Customer>().ToTable("TableCustomer");

            modelBuilder.Entity<Customer>().HasKey(c => c.id); // we can use [Key] on top of Id in model class instead

            // need to create mapping for every class, auto mapping will not happen

            modelBuilder.Entity<Product>().ToTable("TableProduct");

            modelBuilder.Entity<Product>().HasKey(p => p.id);


        }


        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=LAPTOP-1P1TBK2N;Initial Catalog=CustomerDBEF;Integrated Security=True");
        }
        */

        public DbSet<Customer> Customers { get; set; } // no need another one for products

    }
}
