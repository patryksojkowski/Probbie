namespace Probbie.Domain.ValueTypes
{
  internal struct AverageLatency
  {
    public AverageLatency(int value)
    {
      if (value < 0)
        throw new ArgumentOutOfRangeException(nameof(value));

      Value = value;
    }

    public int Value { get; }

    public static implicit operator AverageLatency(int value)
    {
      return new AverageLatency(value);
    }
  }
}
