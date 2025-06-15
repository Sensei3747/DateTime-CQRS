using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DateTime.Application.Users.Login;

public class LoginUserRequestHandler : IQueryHandler<LoginUserRequest, string>
{
    private readonly UserManager<User> _manager;

    public LoginUserRequestHandler(UserManager<User> manager)
    {
        _manager = manager;
    }

    public async Task<Result<string>> Handle(LoginUserRequest request, CancellationToken token)
    {
        var user = await _manager.FindByEmailAsync(request.email);
        var result = await _manager.CheckPasswordAsync(user, request.password);
        if (!result)
        {
            return Result.Failure<string>(UserErrors.NotFound);
        }
        var roles = await _manager.GetRolesAsync(user);
        return Result.Success<string>($"Login Successfull, Welcome {roles[0]}.");
    }
}