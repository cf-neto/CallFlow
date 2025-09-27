using System;
using Microsoft.EntityFrameworkCore;
using CallFlow.Models;

namespace CallFlow.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}