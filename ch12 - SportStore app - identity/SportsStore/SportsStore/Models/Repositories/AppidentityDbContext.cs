using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models.Repositories
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }

        public AppIdentityDbContext()
        {

        }

    /// <summary>
    /// The on configuring.
    /// </summary>
    /// <param name="optionsBuilder">
    /// The options builder.
    /// </param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Db\\identity.db");
        }
    }
}
