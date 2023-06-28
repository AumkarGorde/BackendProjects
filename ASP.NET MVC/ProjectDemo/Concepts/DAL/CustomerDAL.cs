using Concepts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Concepts.DAL
{
    //Here a mistake is made while creating an id, we have marked CustomerId as key but we are also taking it as input from UI but in DB treating as Identity column
    public class CustomerDAL: DbContext
    {
        public DbSet<Customer> dbSet { get; set; }
        public DbSet<UserDetails> dbSetUserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("efCustomer"); // we should provide sql table name here
            modelBuilder.Entity<UserDetails>().ToTable("efCustomerLogin");
        }
    }
}