namespace Vertical_Slice_Architecture.Shared.ResponseResult;

public static class ResultExtension
{
    public static T Match<T>(this Result result, Func<T> onSuccess, Func<IEnumerable<Error>, T> onFailure)
        => result.IsSuccess ? onSuccess() : onFailure(result.Errors);

    public static T Match<T>
        (this Result<T> result, Func<T, T> onSuccess, Func<IEnumerable<Error>, T> onFailure)
        where T : class
        => result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Errors);

    public static void AddErrors(this Result result, IList<Error> errors)
    {
        if (errors is null || errors.Count == 0)
            return;
        result.Errors.AddRange(errors);
    }
}