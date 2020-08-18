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
        public DbSet<Result> Results { get; set; }
        public DbSet<VerificationTest> VerificationTest { get; set; }

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

        }
    }
}
