namespace DateTime.API.Controllers.Program;

public record AddRequest(string name, string location, System.DateTime startTime, System.DateTime endTime, decimal price, int limit);