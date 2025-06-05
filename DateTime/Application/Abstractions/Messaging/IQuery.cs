using DateTime.Domain.Abstractions;
using MediatR;

namespace DateTime.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> {}
