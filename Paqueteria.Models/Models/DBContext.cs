using Microsoft.EntityFrameworkCore;

namespace Paqueteria.Models.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<LocationHistory> LocationHistory { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        public DBContext(DbContextOptions options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>(entity => 
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Carrier)
                      .WithMany(e => e.Deliveries)
                      .HasForeignKey(e => e.CarrierId);

                entity.HasOne(e => e.Vehicle)
                      .WithMany(e => e.Deliveries)
                      .HasForeignKey(e => e.VehicleId);
            });

            modelBuilder.Entity<LocationHistory>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Vehicle)
                      .WithMany(e => e.LocationHistory)
                      .HasForeignKey(e => e.VehicleId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Delivery)
                      .WithMany(e => e.Orders)
                      .HasForeignKey(e => e.DeliveryId);

                entity.HasOne(e => e.Client)
                      .WithMany(e => e.Orders)
                      .HasForeignKey(e => e.ClientId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.Property(e => e.Weight)
                      .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Price)
                      .HasColumnType("decimal(7, 2)");


            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }

    }
}
