using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Interfaces
{
  internal interface IPingSender
  {
    Latency Send(HostAddress address);
  }
}
