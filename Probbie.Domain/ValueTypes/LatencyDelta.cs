namespace Probbie.Domain.ValueTypes
{
  internal readonly struct LatencyDelta
  {
    public LatencyDelta(double value)
    {
      Value = value;
    }

    public double Value { get; }

    public static LatencyDelta Infinity => double.PositiveInfinity;

    public static implicit operator LatencyDelta(double value)
    {
      return new LatencyDelta(value);
    }
  }
}
