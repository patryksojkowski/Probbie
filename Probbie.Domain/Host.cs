using Probbie.Domain.Interfaces;
using Probbie.Domain.ValueTypes;

namespace Probbie.Domain
{
  internal class Host
  {
    private readonly HostAddress _address;
    private readonly IHostHistory _hostHistory;
    private readonly IPingSender _pingSender;

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
      if (average == 0)
      {
        return 0;
      }

      _hostHistory.AddEntry(latency);

      return ((double)latency.Value - average.Value) / average.Value;
    }
  }
}
