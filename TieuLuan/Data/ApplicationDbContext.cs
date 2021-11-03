using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TieuLuan.Models;

namespace TieuLuan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Laptop> Laptop { get; set; }
    }
}
