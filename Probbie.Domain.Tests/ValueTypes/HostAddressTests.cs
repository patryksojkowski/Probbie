using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Tests.ValueTypes
{
  internal class HostAddressTests
  {
    [Test]
    public void HostAddressCannotBeNullOrWhiteSpace()
    {
      Assert.Throws<ArgumentNullException>(() => _ = new HostAddress(null));
      Assert.Throws<ArgumentNullException>(() => _ = new HostAddress(""));
      Assert.Throws<ArgumentNullException>(() => _ = new HostAddress("   "));
    }

    [Test]
    public void HostAddressCanBeString()
    {
      Assert.DoesNotThrow(() => _ = new HostAddress("address"));
    }
  }
}
