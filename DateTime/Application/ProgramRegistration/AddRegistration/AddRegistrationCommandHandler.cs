using DateTime.Application.Abstractions.Clock;
using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Models.ProgramRegistrations;

namespace DateTime.Application.ProgramRegistration.AddRegistration;

public class AddRegistrationCommandHandler : ICommandHandler<AddRegistrationCommand, string>
{
    private readonly IProgramRegistrationRepository _programRegistrationRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AddRegistrationCommandHandler(IProgramRegistrationRepository programRegistrationRepository, IDateTimeProvider dateTimeProvider)
    {
        _programRegistrationRepository = programRegistrationRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<string>> Handle(AddRegistrationCommand command, CancellationToken token)
    {
        var registration = Domain.Models.ProgramRegistrations.ProgramRegistration.Create(command.programId, command.UserId, command.location,command.branchId, _dateTimeProvider.UtcNow);
        await _programRegistrationRepository.Add(registration);
        return $"Registration added with id : {registration.Id}";
    }
}