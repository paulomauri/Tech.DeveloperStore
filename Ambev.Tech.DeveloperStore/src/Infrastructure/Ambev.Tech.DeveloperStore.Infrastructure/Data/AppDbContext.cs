using Microsoft.EntityFrameworkCore;
using Ambev.Tech.DeveloperStore.Domain.Entities;


namespace Ambev.Tech.DeveloperStore.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuthToken> AuthTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasMany(c => c.Items)
                      .WithOne()
                      .HasForeignKey(ci => ci.Id);
                entity.OwnsMany(c => c.Items, item =>
                {
                    item.WithOwner().HasForeignKey("CartId");
                });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

            });

            //modelBuilder.Entity<AuthToken>(entity =>
            //{
            //    entity.HasKey(a => a.Id);
            //    entity.Property(a => a.Token).IsRequired();
            //    entity.Property(a => a.ExpiresAt);
            //    entity.HasOne<User>()
            //          .WithMany()
            //          .HasForeignKey(a => a.UserId);
            //});
        }
    }
}
