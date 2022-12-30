namespace Probbie.Domain.ValueTypes
{
  internal readonly struct HistoryCount
  {
    public HistoryCount(int value)
    {
      if (value < 0)
        throw new ArgumentOutOfRangeException(nameof(value));

      Value = value;
    }

    public int Value { get; }

    public static implicit operator HistoryCount(int value)
    {
      return new HistoryCount(value);
    }
  }
}
