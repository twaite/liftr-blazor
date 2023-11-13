using Liftr.Data;
using Microsoft.EntityFrameworkCore;

public class LiftrContext : DbContext
{
  private readonly ILogger<LiftrContext> _logger;

  public DbSet<Exercise> Exercises { get; set; }

  // Inject options.
  // options: The DbContextOptions{ContactContext} for the context.
  public LiftrContext(DbContextOptions<LiftrContext> options, ILogger<LiftrContext> logger)
      : base(options)
  {
    _logger = logger;
    _logger.LogDebug("Context created!");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    var exerciseNames = new List<string> { "Bench Press", "Squat", "Deadlift", "Overhead Press" };

    var exercises = exerciseNames.Select(name => new Exercise { Id = Guid.NewGuid(), Name = name }).ToArray();

    modelBuilder.Entity<Exercise>().HasData(exercises);
  }

}