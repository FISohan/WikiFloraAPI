using Microsoft.EntityFrameworkCore;
using WikiFloraAPI.Models;

namespace WikiFloraAPI.Data
{
    public class DataContext:DbContext
    {        
        protected readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options,IConfiguration configuration)
            : base(options) { _configuration = configuration; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("sqliteConnectionString"));
            base.OnConfiguring(optionsBuilder);
        }
 
        public DbSet<Flora>Floras { get; set; }
        public DbSet<FloraPhoto> FloraPhoto { get; set; }
    }
}
