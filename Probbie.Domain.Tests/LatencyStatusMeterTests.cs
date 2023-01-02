using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Tests
{
  internal class LatencyStatusMeterTests
  {
    [Test]
    public void GetStatus_ReturnsUnknown_WhenNoHostProvided()
    {
      // Arrange
      var sut = new LatencyStatusMeter(new string[]{});

      // Act
      var result = sut.GetStatus();

      // Assert
      Assert.That(result.Value, Is.EqualTo(State.Unknown));
    }
    
    [Test]
    public void GetStatus_ReturnsGood_WhenHostReturnsLowLatency()
    {
      // Arrange
      var sut = new LatencyStatusMeter(new [] { "localhost" });
      sut.GetStatus();

      // Act
      var result = sut.GetStatus();

      // Assert
      Assert.That(result.Value, Is.EqualTo(State.Good));
    }
    
    [Test]
    public void GetStatus_ReturnsGood_WhenMultipleHostsReturnsLowLatency()
    {
      // Arrange
      var sut = new LatencyStatusMeter(new [] { "localhost", "localhost" });
      sut.GetStatus();

      // Act
      var result = sut.GetStatus();

      // Assert
      Assert.That(result.Value, Is.EqualTo(State.Good));
    }
    
    [Test]
    [Timeout(60000)]
    public void GetStatus_ReturnsGood_WhenMultipleRemoteHostsReturnsAllKindsOfStatuses()
    {
      // Arrange
      var sut = new LatencyStatusMeter(new [] { "1.1.1.1", "8.8.8.8" });
      sut.GetStatus();

      var good = 0;
      var med = 0;
      var bad = 0;
      var terrible = 0;

      // Act && Assert
      while (good == 0 || med == 0 || bad == 0 || terrible == 0)
      {
        var status = sut.GetStatus();

        _ = status.Value switch
        {
          State.Good => good++,
          State.Mediocre => med++,
          State.Bad => bad++,
          State.Terrible => terrible++,
          _ => 0
        };
      }

      Assert.Pass($"good:{good}, med: {med}, bad: {bad}, terrible: {terrible}");
    }
  }
}
