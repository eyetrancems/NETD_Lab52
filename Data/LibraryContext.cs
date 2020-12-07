using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETD_Lab52.Models;
using Microsoft.EntityFrameworkCore;

namespace NETD_Lab52.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Hold> Holds { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Hold>().ToTable("Hold");
            modelBuilder.Entity<Client>().ToTable("Client");
        }
    }
}
