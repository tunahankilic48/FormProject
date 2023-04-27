using FormProject.Domain.Entities;
using FormProject.Infrastructure.EntityTypeConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FormProject.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Field> Fields { get; set; } // Veritabanında tabloların oluşmasını sağlar

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FormConfiguration())
                        .ApplyConfiguration(new FieldConfiguration()); // Veri tabanındaki tabloların hangi kurallara göre oluşturulacağının belirler

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            } // Veritabanında bulunan Foreign Keylerin davranışını belirler

            base.OnModelCreating(modelBuilder);
        }

    }
}
