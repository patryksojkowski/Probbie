namespace Probbie.Domain.ValueTypes
{
  internal readonly struct AverageLatency
  {
    public AverageLatency(double value)
    {
      if (value < 0)
        throw new ArgumentOutOfRangeException(nameof(value));

      Value = value;
    }

    public double Value { get; }

    public static implicit operator AverageLatency(double value)
    {
      return new AverageLatency(value);
    }
    
    public static bool operator ==(AverageLatency a, AverageLatency b)
    {
      return Math.Abs(a.Value - b.Value) < 0.00001;
    }

    public static bool operator !=(AverageLatency a, AverageLatency b)
    {
      return Math.Abs(a.Value - b.Value) > 0.00001;
    }

    public bool Equals(AverageLatency other)
    {
      return this == other;
    }

    public override bool Equals(object? obj)
    {
      return obj is AverageLatency other && Equals(other);
    }

    public override int GetHashCode()
    {
      return Value.GetHashCode();
    }
  }
}
