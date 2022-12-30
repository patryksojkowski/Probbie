using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Tests.ValueTypes
{
  internal class LatencyDeltaTests
  {
    [Test]
    public void LatencyDeltaBeNegative()
    {
      Assert.DoesNotThrow(() => _ = new LatencyDelta(-0.1));
    }

    [Test]
    public void LatencyDeltaCanBeZero()
    {
      Assert.DoesNotThrow(() => _ = new LatencyDelta(0));
    }

    [Test]
    public void LatencyDeltaCanBePositive()
    {
      Assert.DoesNotThrow(() => _ = new LatencyDelta(0.1));
    }

    [Test]
    public void LatencyDeltaCanBePositiveInfinity()
    {
      Assert.DoesNotThrow(() => _ = new LatencyDelta(double.PositiveInfinity));
    }
  }
}
