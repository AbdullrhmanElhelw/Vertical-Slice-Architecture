namespace Vertical_Slice_Architecture.Shared.Infrastructure;

public sealed class ConnectionString
{
    public const string SettingsKey = "DefaultConnection";

    public ConnectionString(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(ConnectionString connectionString) => connectionString.Value;
}