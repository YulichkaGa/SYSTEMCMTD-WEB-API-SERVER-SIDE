using Microsoft.EntityFrameworkCore;
using SYSTEMCMTD_WEB_API_SERVER_SIDE.Models;

namespace SYSTEMCMTD_WEB_API_SERVER_SIDE.Data
{
    public class FullStackDBContext : DbContext
    {
        public FullStackDBContext(DbContextOptions<FullStackDBContext> options) : base(options)
        {
            
        }


        public DbSet<Customer> CustomersDb { get;set;}
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasOne(c => c.Customer).WithMany(c => c.Contacts).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Address>().HasOne(a => a.Customer).WithMany(a => a.Address).HasForeignKey(a => a.CustomerId);

           
        }
    }
}
