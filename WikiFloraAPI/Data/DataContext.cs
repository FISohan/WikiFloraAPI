using Microsoft.EntityFrameworkCore;

namespace WikiFloraAPI.Data
{
    public class DataContext:DbContext
    {        
        protected readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options,IConfiguration configuration) : base(options) { _configuration=configuration }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
            base.OnConfiguring(optionsBuilder);
        }

    }
}
