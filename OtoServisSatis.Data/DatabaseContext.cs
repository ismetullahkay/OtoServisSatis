using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Entities;
using OtoServisSatis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }
        public DbSet<KasaTipis> KasaTipis { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-EQJBFL9\SQLEXPRESS; database=OtoServisSatisNetCore; integrated security=True; MultipleActiveResultSets=True; TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentAPI
            modelBuilder.Entity<Marka>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id=1,
                Adi="Admin"
            });
            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id=1,
                Adi="Admin",
                AktifMi=true,
                EklenmeTarihi=DateTime.Now,
                Email="admin@otoservissatis.tc",
                Sifre="123456",
                //Rol=new Rol { Id=1},
                RolId=1,
                Soyadi="admin",
                Telefon="0850",
                

            });
            modelBuilder.Entity<KasaTipis>().HasData(new KasaTipis
            {
                Id = 1,
                KasaTipi="Sedan",
               
            });
            modelBuilder.Entity<KasaTipis>().HasData(new KasaTipis
            {
                Id = 2,
                KasaTipi = "HatchBack",

            });
            modelBuilder.Entity<KasaTipis>().HasData(new KasaTipis
            {
                Id = 3,
                KasaTipi = "SUV",

            });
            modelBuilder.Entity<KasaTipis>().HasData(new KasaTipis
            {
                Id = 4,
                KasaTipi = "Pick-Up",

            });
            modelBuilder.Entity<KasaTipis>().HasData(new KasaTipis
            {
                Id = 5,
                KasaTipi = "Station",

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
