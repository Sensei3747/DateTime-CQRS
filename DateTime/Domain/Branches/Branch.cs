namespace DateTime.Domain.Branches;

public class Branch {
  public Guid Id { get; set; }
  public string Name { get; set; } = null!;
  public string LocationGroup { get; set; } = null!;
}