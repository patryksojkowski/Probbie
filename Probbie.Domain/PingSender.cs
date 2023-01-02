using System.Net.NetworkInformation;
using Probbie.Domain.Interfaces;
using Probbie.Domain.ValueTypes;

namespace Probbie.Domain
{
  internal class PingSender : IPingSender
  {
    public Latency Send(HostAddress address)
    {
      var ping = new Ping();

      var reply = ping.Send(address.Value);

      if (reply.Status != IPStatus.Success)
      {
        return Latency.Infinity;
      }

      return new Latency((int) reply.RoundtripTime);
    }
  }
}
