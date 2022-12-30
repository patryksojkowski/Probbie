using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Tests
{
  [TestFixture]
  internal class HostHistoryTests
  {

    [Test]
    public void GetAverage_ReturnsAverage()
    {
      // Arrange
      var expectedAverageLatency = new AverageLatency(10);
      var sut = new HostHistory(expectedAverageLatency, 10);

      // Act
      var actualAverageLatency = sut.GetAverage();

      // Assert
      Assert.That(actualAverageLatency, Is.EqualTo(expectedAverageLatency));
    }

    [Test]
    public void AddEntry_UpdatesAverage1()
    {
      // Arrange
      var sut = new HostHistory(10, 9);

      // Act
      sut.AddEntry(20);
      var average = sut.GetAverage();

      // Assert
      Assert.That(average.Value, Is.EqualTo(11));
    }
    
    [Test]
    public void AddEntry_UpdatesAverage2()
    {
      // Arrange
      var sut = new HostHistory(10, 1);

      // Act
      sut.AddEntry(20);
      var average = sut.GetAverage();

      // Assert
      Assert.That(average.Value, Is.EqualTo(15));
    }

    [Test]
    public void AddEntry_UpdatesAverage3()
    {
      // Arrange
      var sut = new HostHistory(10, 1);

      // Act
      sut.AddEntry(10);
      var average = sut.GetAverage();

      // Assert
      Assert.That(average.Value, Is.EqualTo(10));
    }
  }
}
