using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Task>(entity => 
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(e => e.Description)
                .HasDefaultValue(string.Empty);

                entity.Property(e => e.Due)
                .IsRequired();

                entity.Property(e => e.Priority)
                .HasConversion<string>();

                entity.Property(e => e.Status)
                .HasConversion<string>();

                entity.Property(e => e.Tag)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e => e.Attachment)
                .HasMaxLength(255); 

            });
        }

        public override int SaveChanges()
        {
            SetTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, System.Threading.CancellationToken cancellationToken = default)
        {
            SetTimestamps();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
