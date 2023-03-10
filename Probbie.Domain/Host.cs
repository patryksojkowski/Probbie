using Probbie.Domain.Interfaces;
using Probbie.Domain.ValueTypes;

namespace Probbie.Domain
{
  internal class Host
  {
    private readonly HostAddress _address;
    private readonly IHostHistory _hostHistory;
    private readonly IPingSender _pingSender;

    public Host(HostAddress address)
    : this(address, new HostHistory(0,0), new PingSender())
    {
    }

    public Host(HostAddress address, IHostHistory hostHistory, IPingSender pingSender)
    {
      _address = address;
      _hostHistory = hostHistory;
      _pingSender = pingSender;
    }

    public LatencyDelta GetDelta()
    {
      var latency = _pingSender.Send(_address);
      if (latency == int.MaxValue)
        return LatencyDelta.Infinity;


      var average = _hostHistory.GetAverage();
      _hostHistory.AddEntry(latency);
      if (average == 0)
      {
        return 0;
      }

      return ((double)latency.Value - average.Value) / average.Value;
    }
  }
}
