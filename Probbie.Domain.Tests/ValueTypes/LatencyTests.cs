using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Tests.ValueTypes
{
  [TestFixture]
  internal class LatencyTests
  {
    [Test]
    public void LatencyCannotBeNegative()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Latency(-10));
    }

    [Test]
    public void LatencyCanBeZero()
    {
      Assert.DoesNotThrow(() => _ = new Latency(0));
    }

    [Test]
    public void LatencyCanBePositive()
    {
      Assert.DoesNotThrow(() => _ = new Latency(10));
    }
  }
}
