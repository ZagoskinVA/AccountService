using AccountService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.DataBase
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
