using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckDriverApp.Model;

namespace TruckDriverApp.Context
{
    public class TruckDriverAppDbContext : DbContext
    {

        public TruckDriverAppDbContext(DbContextOptions<TruckDriverAppDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<registermodel> rRegisterModel { get; set; }
        //public virtual DbSet<Login> Login { get; set; }
       
        
        public virtual DbSet<planfrieght> PPlanFrieght{ get; set; }
       
       
    }
    
}
