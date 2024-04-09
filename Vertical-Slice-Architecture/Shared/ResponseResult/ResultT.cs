namespace Vertical_Slice_Architecture.Shared.ResponseResult;

public class Result<T> : Result
{
    public T? Value { get; }

    public Result(
        bool isSuccess,
        List<Error> errors,
        T value)
        : base(isSuccess, errors) => Value = value;
}