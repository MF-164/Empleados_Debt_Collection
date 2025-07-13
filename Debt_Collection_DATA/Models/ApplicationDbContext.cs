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
    }
    
    
}
