using EF = Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AddressBook.Api.Entity;

namespace AddressBook.Api.DbContext
{
    public class AddressBookDbContext : EF.DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public AddressBookDbContext(DbContextOptions options) : base(options) { }
    }
}