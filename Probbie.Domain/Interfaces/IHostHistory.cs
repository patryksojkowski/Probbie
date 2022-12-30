using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Interfaces
{
  internal interface IHostHistory
  {
    AverageLatency GetAverage();
    void AddEntry(Latency latency);
  }
}
