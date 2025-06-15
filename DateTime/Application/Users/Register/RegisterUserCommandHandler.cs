using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace DateTime.Application.Users.Register;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, string>
{
    private readonly UserManager<User> _manager;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(UserManager<User> manager, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _manager = manager;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(RegisterUserCommand command, CancellationToken token)
    {
        var existingUser = await _manager.FindByEmailAsync(command.email);
        if (existingUser is not null)
        {
            return Result.Failure<string>(UserErrors.AlreadyExists);
        }
        var user = User.Create(command.userName, command.email);
        await _userRepository.Add(user, command.password);
        await _manager.AddToRoleAsync(user, command.role);
        await _unitOfWork.SaveChangesAsync();
        return user.Email;
    }
}