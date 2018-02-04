using CarFuelCore.Models;
using Microsoft.EntityFrameworkCore; 

namespace CarFuelCore.Data {
  public class CarFuelCoreDb : DbContext {

    public CarFuelCoreDb(DbContextOptions<CarFuelCoreDb> options) : base(options) {
      //
    }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder
        .Entity<Car>()
        .Property(t => t.Model)
        .HasAnnotation("AuthorName", "Suthep S");
    }
  }
}