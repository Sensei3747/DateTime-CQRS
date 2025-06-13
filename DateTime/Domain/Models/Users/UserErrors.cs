using DateTime.Domain.Abstractions;

namespace DateTime.Domain.Models.Users;
public static class UserErrors
{
    public static Error AlreadyExists = Error.Conflict(
        "User.AlreadyExists",
        "User with provided email already exists");

    public static Error NotFound = Error.NotFound(
        "User.NotFound",
        "The user with the specified identifier was not found");

    public static Error InvalidCredentials = Error.Conflict(
        "User.InvalidCredentials",
        "The provided credentials were invalid");

}