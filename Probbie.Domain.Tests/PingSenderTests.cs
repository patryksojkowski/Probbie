using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Tests
{
  [TestFixture]
  internal class PingSenderTests
  {
    [Test]
    public void Send_SentToLocalhost_ReturnsLatency()
    {
      // Arrange
      var sut = new PingSender();

      // Act
      var latency = sut.Send("localhost");

      // Assert
      Assert.That(latency.Value, Is.LessThan(10));
    }

    [Test]
    public void Send_SentGoogleDns_ReturnsLatency()
    {
      // Arrange
      var sut = new PingSender();

      // Act
      var latency = sut.Send("8.8.8.8");

      // Assert
      Assert.That(latency.Value, Is.LessThan(Latency.Infinity.Value));
    }

    [Test]
    public void Send_SentToUnreachableAddress_ReturnsInfinity()
    {
      // Arrange
      var sut = new PingSender();

      // Act
      var latency = sut.Send("1.2.3.4");

      // Assert
      Assert.That(latency, Is.EqualTo(Latency.Infinity));
    }
  }
}
