using MediatR;
using Vertical_Slice_Architecture.Shared.ResponseResult;

namespace Vertical_Slice_Architecture.Shared.CQRS.Queries;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}