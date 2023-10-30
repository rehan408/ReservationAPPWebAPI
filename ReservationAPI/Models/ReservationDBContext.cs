using Microsoft.EntityFrameworkCore;

namespace ReservationAPI.Models
{
    public class ReservationDBContext: DbContext
    {
        public ReservationDBContext()
        {
        }

        public ReservationDBContext(DbContextOptions<ReservationDBContext> options)
        : base(options)
    {
        }

        // Define DbSet properties to represent database tables
        public DbSet<ReservationData> tb_reservations { get; set; }

        // Add DbSet properties for other tables if needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure table relationships and constraints if necessary
            // modelBuilder.Entity<EntityName>().HasMany...
        }
    }
}
