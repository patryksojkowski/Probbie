namespace Probbie.Domain.ValueTypes
{
  public readonly struct LatencyStatus
  {
    public LatencyStatus(State value)
    {
      Value = value;
    }

    public State Value { get; }

    public static implicit operator LatencyStatus(State value)
    {
      return new LatencyStatus(value);
    }

    public static bool operator ==(LatencyStatus a, LatencyStatus b)
    {
      return a.Value == b.Value;
    }
    public static bool operator !=(LatencyStatus a, LatencyStatus b)
    {
      return a.Value != b.Value;
    }

    public bool Equals(LatencyStatus other)
    {
      return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
      return obj is LatencyStatus other && Equals(other);
    }

    public override int GetHashCode()
    {
      return (int)Value;
    }
  }

  public enum State
  {
    Unknown,
    Good,
    Mediocre,
    Bad,
    Terrible
  }
}
