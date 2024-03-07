using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<Pais> Pais { get; set; }
        public DbSet<Barrio> Barrio { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Deposito> Deposito { get; set; }
    }
}