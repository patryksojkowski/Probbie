using Moq;
using Probbie.Domain.Interfaces;
using Probbie.Domain.ValueTypes;

namespace Probbie.Domain.Tests
{
  [TestFixture]
  internal class HostTests
  {
    private readonly Mock<IHostHistory> _hostHistoryMock = new();
    private readonly Mock<IPingSender> _pingSenderMock = new();
    private readonly HostAddress _address = "address";

    [Test]
    public void GetDelta_ReturnsValue()
    {
      // Arrange
      var sut = new Host(_address, _hostHistoryMock.Object, _pingSenderMock.Object);
      
      // Act
      var delta = sut.GetDelta();

      // Assert
      Assert.That(delta, Is.InstanceOf<LatencyDelta>());
    }
    
    [Test]
    public void GetDelta_CallsHostHistoryGetAverage()
    {
      // Arrange
      var sut = new Host(_address, _hostHistoryMock.Object, _pingSenderMock.Object);

      // Act
      _ = sut.GetDelta();

      // Assert
      _hostHistoryMock.Verify(x => x.GetAverage());
    }
    
    [Test]
    public void GetDelta_CallsHostHistoryAddEntry()
    {
      // Arrange
      var sut = new Host(_address, _hostHistoryMock.Object, _pingSenderMock.Object);

      // Act
      _ = sut.GetDelta();

      // Assert
      _hostHistoryMock.Verify(x => x.AddEntry(It.IsAny<Latency>()));
    }
    
    [Test]
    public void GetDelta_CallsPing()
    {
      // Arrange
      var sut = new Host(_address, _hostHistoryMock.Object, _pingSenderMock.Object);

      // Act
      _ = sut.GetDelta();

      // Assert
      _pingSenderMock.Verify(x => x.Send(_address));
    }

    [Test]
    public void GetDelta_CallsPingAndCallsHostHistoryAddEntry()
    {
      // Arrange
      Latency expectedPingLatency = 10;
      _pingSenderMock.Setup(x => x.Send(_address)).Returns(expectedPingLatency);

      var sut = new Host(_address, _hostHistoryMock.Object, _pingSenderMock.Object);
      // Act
      _ = sut.GetDelta();

      // Assert
      _hostHistoryMock.Verify(x => x.AddEntry(expectedPingLatency));
    }
    
    [Test]
    [TestCase(10, 5, 1)]
    [TestCase(15, 5, 2)]
    [TestCase(5, 5, 0)]
    [TestCase(6, 5, 0.2)]
    [TestCase(7, 5, 0.4)]
    [TestCase(4, 5, -0.2)]
    [TestCase(1, 5, -0.8)]
    [TestCase(1, 0, 0)]
    [TestCase(int.MaxValue, 10, double.PositiveInfinity)]
    public void GetDelta_CalculatesCorrectDelta(int latencyInput, int averageInput, double expectedDeltaInput)
    {
      // Arrange
      Latency pingLatency = latencyInput;
      AverageLatency average = averageInput;
      LatencyDelta expectedDelta = expectedDeltaInput;

      _pingSenderMock.Setup(x => x.Send(_address)).Returns(pingLatency);
      _hostHistoryMock.Setup(x => x.GetAverage()).Returns(average);

      var sut = new Host(_address, _hostHistoryMock.Object, _pingSenderMock.Object);
      // Act
      var delta = sut.GetDelta();

      // Assert
      Assert.That(delta, Is.EqualTo(expectedDelta));
    }
  }
}
