using Liftr.Data;
using Microsoft.EntityFrameworkCore;

public class LiftrContext : DbContext
{
  public DbSet<Exercise> Exercises { get; set; }

  // TODO: read config 
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseNpgsql(@"Host=localhost;Username=user;Password=password;Database=liftr_db;Port=5433");

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    var exerciseNames = new List<string> { "Bench Press", "Squat", "Deadlift", "Overhead Press" };

    var exercises = exerciseNames.Select(name => new Exercise { Id = Guid.NewGuid(), Name = name }).ToArray();

    modelBuilder.Entity<Exercise>().HasData(exercises);
  }
}