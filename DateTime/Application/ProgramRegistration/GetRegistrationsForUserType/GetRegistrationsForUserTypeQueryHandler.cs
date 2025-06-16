using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Models.ProgramRegistrations;

namespace DateTime.Application.ProgramRegistration;

public class GetRegistrationsForUserTypeQueryHandler : IQueryHandler<GetRegistrationsForUserTypeQuery, List<ProgramRegistrationDto>>
{
    private readonly IProgramRegistrationRepository _programRegistrationRepository;

    public GetRegistrationsForUserTypeQueryHandler(IProgramRegistrationRepository programRegistrationRepository)
    {
        _programRegistrationRepository = programRegistrationRepository;
    }

    public async Task<Result<List<ProgramRegistrationDto>>> Handle(GetRegistrationsForUserTypeQuery query, CancellationToken token)
    {
        var registrations = await _programRegistrationRepository.GetByUserId(query.userId);
        return registrations;
    }
}