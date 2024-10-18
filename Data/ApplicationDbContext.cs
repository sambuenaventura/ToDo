using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Task = api.Models.Task; // Alias the Task model

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

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }


        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);

        //     modelBuilder.Entity<Models.Task>(entity => 
        //     {
        //         entity.HasKey(e => e.Id);

        //         entity.Property(e => e.Name)
        //         .IsRequired()
        //         .HasMaxLength(255);

        //         entity.Property(e => e.Description)
        //         .HasDefaultValue(string.Empty);

        //         entity.Property(e => e.Due)
        //         .IsRequired();

        //         entity.Property(e => e.Priority)
        //         .HasConversion<string>();

        //         entity.Property(e => e.Status)
        //         .HasConversion<string>();

        //         entity.Property(e => e.Tag)
        //         .HasMaxLength(100)
        //         .IsRequired();

        //         entity.Property(e => e.Attachment)
        //         .HasMaxLength(255); 

        //     });
        // }

    }
}
