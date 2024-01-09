using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr2.Models
{
    public class VstupDBContext : DbContext
    {
        protected string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Oleksandr\Desktop\Programming2\mkr2\Vstup.mdf;Integrated Security=True";
        public VstupDBContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Abiturient> Abiturients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abiturient>().ToTable("Abiturients");
        }
    }
}