namespace Probbie.Domain.ValueTypes
{
  internal readonly struct Latency
  {
    public Latency(int value)
    {
      if (value < 0)
        throw new ArgumentOutOfRangeException(nameof(value));

      Value = value;
    }

    public int Value { get; }

    public static implicit operator Latency(int value)
    {
      return new Latency(value);
    }

    public static bool operator ==(Latency a, Latency b)
    {
      return a.Value == b.Value;
    }

    public static bool operator !=(Latency a, Latency b)
    {
      return a.Value != b.Value;
    }

    public bool Equals(Latency other)
    {
      return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
      return obj is Latency other && Equals(other);
    }

    public override int GetHashCode()
    {
      return Value;
    }
  }
}
