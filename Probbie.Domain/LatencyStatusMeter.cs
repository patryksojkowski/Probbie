using Probbie.Domain.ValueTypes;

namespace Probbie.Domain
{
  public class LatencyStatusMeter
  {
    private readonly IList<Host> _hosts = new List<Host>();

    public LatencyStatusMeter(IEnumerable<string> addresses)
    {
      Initialize(addresses);
    }

    private void Initialize(IEnumerable<string> addresses)
    {
      foreach (var item in addresses)
      {
        _hosts.Add(new Host(item));
      }
    }

    public LatencyStatus GetStatus()
    {
      if (!_hosts.Any())
      {
        return State.Unknown;
      }

      var deltas = _hosts.Select(x => x.GetDelta().Value);

      var mean = deltas.Average();

      return CalculateState(mean);
    }

    private State CalculateState(double mean) => mean switch
    {
      <= 0.4 => State.Good,
      <= 1 => State.Mediocre,
      <= 5 => State.Bad,
      _ => State.Terrible
    };
  }
}
