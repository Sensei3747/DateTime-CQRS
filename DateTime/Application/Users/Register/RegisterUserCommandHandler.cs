using DateTime.Application.Abstractions.Messaging;
using DateTime.Application.Abstractions.Auth;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Users;

namespace DateTime.Application.Users.Register;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, string>
{
    public IPasswordHasher _passwordHasher;
    public IUserRepository _userRepository;
    public IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(IPasswordHasher passwordHasher, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<string>> Handle(RegisterUserCommand request, CancellationToken token)
    {
        var existingUser = await _userRepository.GetByEmail(request.email);
        if (existingUser is not null)
        {
            return Result.Failure<string>(UserErrors.AlreadyExists);
        }
        var hashedPassword = _passwordHasher.HashPassword(request.password);
        var user = User.Create(request.email, hashedPassword);
        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync();
        return user.Email;
    }
}