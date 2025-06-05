using DateTime.Domain.ProgramRegistrations;

namespace DateTime.Domain.Program;

public class Programs
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public System.DateTime StartTime { get; set; }
    public System.DateTime EndTime { get; set; }
    public decimal Price { get; set; }
    public int Limit { get; set; }
    public ICollection<ProgramRegistration> Registrations { get; set; }

    private Programs() { }

    public Programs(string name, string location, System.DateTime startTime, System.DateTime endTime, decimal price, int limit)
    {
        Name = name;
        Location = location;
        StartTime = startTime;
        EndTime = endTime;
        Price = price;
        Limit = limit;
    }

    public static Programs Create(string name, string location, System.DateTime startTime, System.DateTime endTime, decimal price, int limit)
    {
        var program = new Programs(name, location, startTime, endTime, price, limit);
        return program;
    }
}