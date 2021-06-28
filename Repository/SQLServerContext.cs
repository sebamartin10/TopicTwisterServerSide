﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    
    public class SQLServerContext : DbContext
    {
        
        public DbSet<Player> Players { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL5101.site4now.net;Initial Catalog=db_a76b7c_jsmartin;User Id=db_a76b7c_jsmartin_admin;Password=Gringo544");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Player>(entity => {
                entity.ToTable("Player");
            });
        }
    }
}