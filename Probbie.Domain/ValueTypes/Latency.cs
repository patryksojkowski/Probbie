namespace Probbie.Domain.ValueTypes
{
  internal struct Latency
  {
    public Latency(int value)
    {
      if (value < 0)
        throw new ArgumentOutOfRangeException(nameof(value));

      Value = value;
    }

    public int Value { get; set; }

    public static implicit operator Latency(int value)
    {
      return new Latency(value);
    }
  }
}
