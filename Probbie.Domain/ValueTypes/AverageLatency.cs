namespace Probbie.Domain.ValueTypes
{
  internal readonly struct AverageLatency
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
    
    public static bool operator ==(AverageLatency a, AverageLatency b)
    {
      return a.Value == b.Value;
    }

    public static bool operator !=(AverageLatency a, AverageLatency b)
    {
      return a.Value != b.Value;
    }

    public bool Equals(AverageLatency other)
    {
      return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
      return obj is AverageLatency other && Equals(other);
    }

    public override int GetHashCode()
    {
      return Value;
    }
  }
}
