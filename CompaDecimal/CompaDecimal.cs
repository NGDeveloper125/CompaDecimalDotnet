namespace CompaDecimalSystem;

public record CompaDecimal
{
    public string Value { get; }

    public CompaDecimal(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }
}
