namespace DateTime.Domain.Program;

public class ProgramDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public System.DateTime LocalStartTime { get; set; }
    public System.DateTime LocalEndTime { get; set; }
    public decimal Price { get; set; }
    public int Limit { get; set; }
}