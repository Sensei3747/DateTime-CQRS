namespace DateTime.Domain.Models.Branches;

public class Branch
{
  public string Id { get; set; }
  public string Name { get; set; } = null!;
  public string LocationGroup { get; set; } = null!;
}