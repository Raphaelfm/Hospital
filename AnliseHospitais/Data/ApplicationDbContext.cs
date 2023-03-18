using AnliseHospitais.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnliseHospitais.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HospitalModel> Hospitais { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Define o mapeamento da tabela Hospitais

            builder.Entity<HospitalModel>()
                .ToTable("Hospitais")
                .HasKey(h => h.Id);
        }
    }
}