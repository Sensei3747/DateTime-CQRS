namespace DateTime.Application.Abstractions.Services;

public interface IPermissionChecker
{
    Task<bool> HasPermissionAsync(string userId, string permissionName);
}