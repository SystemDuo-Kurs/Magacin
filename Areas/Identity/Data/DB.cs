using Magacin.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Magacin.Data;

public class DB : IdentityDbContext<Magacioner>
{
    public DB(DbContextOptions<DB> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Magacioner>().Ignore(m => m.ClearTextPassword);
       
    }

    public DbSet<Magacioner> Magacioners { get; set; }
}
