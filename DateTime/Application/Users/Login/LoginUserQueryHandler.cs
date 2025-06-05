using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Users;
using DateTime.Application.Abstractions.Auth;
using DateTime.Domain.Abstractions;

namespace DateTime.Application.Users.Login;

internal sealed class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, string>
{
    public IPasswordHasher _passwordHasher;
    public IUnitOfWork _unitOfWork;
    public IUserRepository _userRepository;

    public LoginUserQueryHandler(IPasswordHasher passwordHasher, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<string>> Handle(LoginUserQuery request, CancellationToken token)
    {
        var user = await _userRepository.GetByEmail(request.email);
        if (user is null)
        {
            return Result.Failure<string>(UserErrors.NotFound);
        }
        var isValidPassword = _passwordHasher.Verify(request.hashPassword, user.PasswordHash);
        if (!isValidPassword)
        {
            return Result.Failure<string>(UserErrors.InvalidCredentials);
        }
        var res = "Login Successful";
        return Result.Success<string>(res);
    }
}