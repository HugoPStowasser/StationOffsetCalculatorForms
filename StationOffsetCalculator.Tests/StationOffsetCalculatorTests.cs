using StationOffsetCalculator.Core.Models;

namespace StationOffsetCalculator.Tests
{
    [TestClass]
    public class StationOffsetCalculatorTests
    {
        [TestMethod]
        public void Calculate_PointOnPolyline_ReturnsZeroOffset()
        {
            var points = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10)
            };
            var polyline = new Polyline(points);
            var calculator = new StationOffsetCalculator.Core.Services.StationOffsetCalculator();
            var targetPoint = new Point(5, 0);

            var result = calculator.Calculate(polyline, targetPoint);

            Assert.AreEqual(5, result.Station, 0.0001);
            Assert.AreEqual(0, result.Offset, 0.0001);
            Assert.AreEqual(5, result.NearestPoint.X, 0.0001);
            Assert.AreEqual(0, result.NearestPoint.Y, 0.0001);
        }

        [TestMethod]
        public void Calculate_PointNotOnPolyline_ReturnsCorrectStationAndOffset()
        {
            var points = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10)
            };
            var polyline = new Polyline(points);
            var calculator = new Core.Services.StationOffsetCalculator();
            var targetPoint = new Point(5, 5);

            var result = calculator.Calculate(polyline, targetPoint);

            Assert.AreEqual(5, result.Station, 0.0001);
            Assert.AreEqual(5, result.Offset, 0.0001);
            Assert.AreEqual(5, result.NearestPoint.X, 0.0001);
            Assert.AreEqual(0, result.NearestPoint.Y, 0.0001);
        }

        [TestMethod]
        public void Calculate_PointNearestToSecondSegment_ReturnsCorrectStationAndOffset()
        {
            var points = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10)
            };
            var polyline = new Polyline(points);
            var calculator = new Core.Services.StationOffsetCalculator();
            var targetPoint = new Point(15, 5);

            var result = calculator.Calculate(polyline, targetPoint);

            Assert.AreEqual(15, result.Station, 0.0001);
            Assert.AreEqual(5, result.Offset, 0.0001);
            Assert.AreEqual(10, result.NearestPoint.X, 0.0001);
            Assert.AreEqual(5, result.NearestPoint.Y, 0.0001);
        }
    }
}