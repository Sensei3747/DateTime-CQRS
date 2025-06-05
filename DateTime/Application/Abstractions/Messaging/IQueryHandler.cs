
using MediatR;
using DateTime.Domain.Abstractions;

namespace DateTime.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse> {}

