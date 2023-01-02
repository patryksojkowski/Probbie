using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Tests.Integration
{
  internal class HostIntegrationTests
  {
    [Test]
    public void Host_GetDelta_Integration()
    {
      HostAddress address = "8.8.8.8";
      var sut = new Host(address, new HostHistory(0, 0), new PingSender());

      while (sut.GetDelta().Value != 0);

      while (sut.GetDelta().Value > 0);

      while (sut.GetDelta().Value < 0);

      Assert.IsTrue(true);
    }
  }
}
