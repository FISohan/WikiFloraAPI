﻿using Microsoft.EntityFrameworkCore;
using WikiFloraAPI.Models;
using WikiFloraAPI.Services;

namespace WikiFloraAPI.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
            : base(options) { _configuration = configuration; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("sqliteConnectionString"));
            
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Flora> Floras { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}
