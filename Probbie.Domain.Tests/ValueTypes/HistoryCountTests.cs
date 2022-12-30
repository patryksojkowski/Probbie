using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Tests.ValueTypes
{
  [TestFixture]
  internal class HistoryCountTests
  {
    [Test]
    public void HistoryCountCannotBeNegative()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => _ = new HistoryCount(-10));
    }

    [Test]
    public void HistoryCountCanBeZero()
    {
      Assert.DoesNotThrow(() => _ = new HistoryCount(0));
    }

    [Test]
    public void HistoryCountCanBePositive()
    {
      Assert.DoesNotThrow(() => _ = new HistoryCount(10));
    }
  }
}
