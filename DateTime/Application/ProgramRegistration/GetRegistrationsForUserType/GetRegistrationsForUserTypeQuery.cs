using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Models.ProgramRegistrations;

namespace DateTime.Application.ProgramRegistration;

public record GetRegistrationsForUserTypeQuery(string userId) : IQuery<List<ProgramRegistrationDto>>;