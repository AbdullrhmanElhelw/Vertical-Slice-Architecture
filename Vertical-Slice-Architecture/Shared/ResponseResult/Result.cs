namespace Vertical_Slice_Architecture.Shared.ResponseResult;

public class Result
{
    protected Result(bool isSuccess, List<Error> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public bool IsSuccess { get; }

    public List<Error> Errors { get; }

    public static Result Success() => new(true, [Error.None]);

    public static Result Failure(List<Error> errors) => new(false, errors);

    public static Result Failure(Error error) => new(false, [error]);

    public static Result<T> Success<T>(T value) => new(true, [Error.None], value);

    public static Result<T> Failure<T>(Error error) => new(false, [error], default!);

    public static Result<T> Failure<T>(List<Error> errors) => new(false, errors, default!);
}