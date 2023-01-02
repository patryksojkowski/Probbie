namespace Probbie.Domain.ValueTypes
{
  public readonly struct HostAddress
  {
    public string Value { get; }

    public HostAddress(string value)
    {
      if(string.IsNullOrWhiteSpace(value))
        throw new ArgumentNullException(nameof(value));

      Value = value;
    }

    public static implicit operator HostAddress(string value)
    {
      return new HostAddress(value);
    }
  }
}
