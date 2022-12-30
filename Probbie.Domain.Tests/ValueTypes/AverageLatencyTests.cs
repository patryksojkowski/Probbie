using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Tests.ValueTypes
{
  [TestFixture]
  internal class AverageLatencyTests
  {
    [Test]
    public void AverageLatencyCannotBeNegative()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => _ = new AverageLatency(-10));
    }
    
    [Test]
    public void AverageLatencyCanBeZero()
    {
      Assert.DoesNotThrow(() => _ = new AverageLatency(0));
    }
    
    [Test]
    public void AverageLatencyCanBePositive()
    {
      Assert.DoesNotThrow(() => _ = new AverageLatency(10));
    }
  }
}
