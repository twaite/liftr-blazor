using System.ComponentModel.DataAnnotations;

namespace Liftr.Data;

public class Exercise
{
  public Guid Id { get; set; }

  [Required]
  public string Name { get; set; }
}