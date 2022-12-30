using Probbie.Domain.Interfaces;
using Probbie.Domain.ValueTypes;

namespace Probbie.Domain
{
  internal class HostHistory : IHostHistory
  {
    private HistoryCount _historyCount;
    private AverageLatency _averageLatency;

    public HostHistory(AverageLatency averageLatency, HistoryCount historyCount)
    {
      _averageLatency = averageLatency;
      _historyCount = historyCount;
    }

    public AverageLatency GetAverage()
    {
      return _averageLatency;
    }

    public void AddEntry(Latency latency)
    {
      _averageLatency = (_historyCount.Value * _averageLatency.Value + latency.Value) / (_historyCount.Value + 1);

      _historyCount = _historyCount.Value + 1;
    }
  }
}