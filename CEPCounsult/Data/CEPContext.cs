using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEPCounsult.Models;
using Microsoft.EntityFrameworkCore;

namespace CEPCounsult.Data
{
    public class CEPContext : DbContext
    {
        public CEPContext(DbContextOptions<CEPContext> options) : base(options)
        {
        }

        public DbSet<CEP> CEPs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CEP>().ToTable("CEP");
        }
    }
}
