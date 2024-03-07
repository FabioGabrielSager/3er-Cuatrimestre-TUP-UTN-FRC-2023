using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class ZoosContext : DbContext
    {
        public ZoosContext(DbContextOptions<ZoosContext> options) : base(options){

        }

        public DbSet<Animal> Animales { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Zoo> Zoos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    }
}