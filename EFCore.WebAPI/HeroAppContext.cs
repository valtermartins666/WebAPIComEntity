using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.WebAPI
{
    public partial class HeroAppContext : DbContext
    {
        public HeroAppContext()
        {
        }

        public HeroAppContext(DbContextOptions<HeroAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Armas> Armas { get; set; }
        public virtual DbSet<Batalhas> Batalhas { get; set; }
        public virtual DbSet<Herois> Herois { get; set; }
        public virtual DbSet<HeroisBatalhas> HeroisBatalhas { get; set; }
        public virtual DbSet<IdentidadesSecretas> IdentidadesSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Password=@cessoSQL1982;Persist Security Info=True;User ID=sa;Data Source=DESKTOP-IEK2ODL\\SQLEXPRESS;Initial Catalog=HeroApp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Armas>(entity =>
            {
                entity.HasIndex(e => e.HeroiId);

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.Armas)
                    .HasForeignKey(d => d.HeroiId);
            });

            modelBuilder.Entity<HeroisBatalhas>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });

                entity.HasIndex(e => e.HeroiId);

                entity.HasOne(d => d.Batalha)
                    .WithMany(p => p.HeroisBatalhas)
                    .HasForeignKey(d => d.BatalhaId);

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.HeroisBatalhas)
                    .HasForeignKey(d => d.HeroiId);
            });

            modelBuilder.Entity<IdentidadesSecretas>(entity =>
            {
                entity.HasIndex(e => e.HeroiId)
                    .IsUnique();

                entity.HasOne(d => d.Heroi)
                    .WithOne(p => p.IdentidadesSecretas)
                    .HasForeignKey<IdentidadesSecretas>(d => d.HeroiId);
            });
        }
    }
}
