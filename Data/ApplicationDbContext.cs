using ClubDeportivoAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClubDeportivoAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<Socio> Socios { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Carnet> Carnets { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Apto> Aptos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            base.OnModelCreating(modelBuilder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };

            //ejempplo realcion m:m ((((tener en cuenta que en las pocos que relacionan debe estar el listado de la tabla intermedia))))
            /*builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            builder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.StockId);*/

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            modelBuilder.Entity<Cuota>().HasKey(c => new { c.Id, c.FechaPago });
        }

    }
}
