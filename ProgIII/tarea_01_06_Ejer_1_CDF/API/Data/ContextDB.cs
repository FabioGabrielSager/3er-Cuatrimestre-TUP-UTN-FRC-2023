using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clases.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(){}

        public ContextDB(DbContextOptions<ContextDB> options): base(options){
             
        }
        
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Barco> Barcos { get; set; }
    }
}