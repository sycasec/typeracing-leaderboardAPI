using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace typeRacingAPI.Data {
    public class DataContext : DbContext {

        protected readonly IConfiguration Config;
        public DataContext(IConfiguration config){
            Config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseNpgsql(Config.GetConnectionString("typeRacingDatabase"));
        }

        public DbSet<Player> Players => Set<Player>();
    }
}