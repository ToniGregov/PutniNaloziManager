using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PutniNalozi.Models;
using Microsoft.EntityFrameworkCore;
using PutniNaloziManager.Models;

namespace PutniNalozi.Data
{
    public class PutniNaloziDBContext : DbContext
    {
        public PutniNaloziDBContext(DbContextOptions<PutniNaloziDBContext> options) : base(options) {}

        public DbSet<Automobil> Automobili { get; set; }
        public DbSet<Putnik> Putnici { get; set; }
        public DbSet<PutniNalog> PutniNalozi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PutniNaloziPutnici>().HasKey(pnp => new { pnp.PutnikId, pnp.PutniNalogId });
            modelBuilder.Entity<Automobil>().ToTable("Automobili");
            modelBuilder.Entity<Putnik>().ToTable("Putnici");
            modelBuilder.Entity<PutniNalog>().ToTable("PutniNalozi");
            modelBuilder.Entity<PutniNaloziPutnici>().ToTable("PutniNaloziPutnici");
        }
        protected void Create() { }
    }
}

