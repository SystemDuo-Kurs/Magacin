using Magacin.Areas.Identity.Data;
using Magacin.Models;
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
        builder.Entity<Item>().HasKey(i => i.Id);
        builder.Entity<IO>().HasKey(i => i.Id);
    }

    public DbSet<Magacioner> Magacioners { get; set; }

    public DbSet<Item> Items { get; set; }
    public DbSet<IO> IOs { get; set; }
}
