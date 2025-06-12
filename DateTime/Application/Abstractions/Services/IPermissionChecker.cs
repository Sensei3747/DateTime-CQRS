namespace DateTime.Application.Abstractions.Services;

public interface IPermissionChecker
{
    Task<bool> HasPermissionAsync(Guid userId, string permissionName);
}