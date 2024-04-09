namespace Vertical_Slice_Architecture.Shared.ResponseResult;

public sealed record Error
    (string Message)
{
    public static readonly Error None = new(string.Empty);
    public static implicit operator string(Error error) => error.Message;
    public static implicit operator Error(string message) => new(message);
}