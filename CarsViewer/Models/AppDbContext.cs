using Microsoft.EntityFrameworkCore;

namespace CarsViewer.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {            
        }

        public DbSet<Car> Cars { get; set; }
    }
}
