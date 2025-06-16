namespace DateTime.API.Controllers.Participants;

public record CreateParticipantRequest(string name, string branchId, string createdByUserId);