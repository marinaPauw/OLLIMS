using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OLLIMS.Models;

namespace OLLIMS.Data
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<LaboratoryToInstrument> LaboratoryToInstruments { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<VerificationTest> VerificationTest { get; set; }

        public DbSet<VerificationTestToResult> VerificationTestToResult { get; set; }
        public DbSet<InstrumentToVerificationTests> InstrumentToVerificationTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrument>().HasKey(
                t => new { t.ID }
            );
            modelBuilder.Entity<Result>().HasKey(
                t => new { t.ID }
            );
            modelBuilder.Entity<VerificationTest>().HasKey(
                t => new { t.ID }
            );
            modelBuilder.Entity<VerificationTestToResult>().HasKey(
                t => new { t.ID }
            );
            modelBuilder.Entity<InstrumentToVerificationTests>().HasKey(
                t => new { t.ID }
            );
            modelBuilder.Entity<Laboratory>().HasKey(
                t => new { t.ID }
            );
            modelBuilder.Entity<LaboratoryToInstrument>().HasOne(t => t.Instrument).WithOne(t=>t.LaboratoryToInstrument)
            .HasForeignKey<Instrument>(t => new { t.ID });
        }
    }
}
