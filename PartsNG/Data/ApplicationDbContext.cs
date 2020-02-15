using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PartsNG.Models;

namespace PartsNG.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PartProperty>()
                .HasKey(pp => new { pp.PartId, pp.PropertyId });
            builder.Entity<PartProperty>()
                .HasOne(pp => pp.Part)
                .WithMany(p => p.PartProperties);
            builder.Entity<PartProperty>()
                .HasOne(pp => pp.Property)
                .WithMany(p => p.PartProperties);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);

            base.OnModelCreating(builder);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartProperty> PartProperties { get; set; }
        public DbSet<Property> Properties { get; set; }

    }
}
