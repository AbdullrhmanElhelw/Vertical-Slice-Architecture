using MediatR;
using Vertical_Slice_Architecture.Shared.ResponseResult;

namespace Vertical_Slice_Architecture.Shared.CQRS.Queries;

public interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}