using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        // DbSet properties for your entities
        public DbSet<Client> Clients { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Agent> Agents { get; set; }

        public DbSet<InvoiceRecord> InvoiceRecords { get; internal set; }

        public DbSet<MonthlyWorkReport> MonthlyWorkReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<MonthlyWorkReport>()
                .HasIndex(r => new { r.ClientId, r.SiteId, r.Month, r.Year })
                .IsUnique();

            modelBuilder.Entity<MonthlyWorkReport>()
                .HasOne(r => r.Client)
                .WithMany()
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MonthlyWorkReport>()
                .HasOne(r => r.Site)
                .WithMany()
                .HasForeignKey(r => r.SiteId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }


}
