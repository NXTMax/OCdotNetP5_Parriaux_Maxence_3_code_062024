using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarRepair> CarRepairs { get; set; }

        public DbSet<Repair> Repairs { get; set; }
    }
}
