using StationOffsetCalculator.Core.Models;

namespace StationOffsetCalculator.Tests
{
    [TestClass]
    public class StationOffsetCalculatorTests
    {
        [TestMethod]
        public void Calculate_PointOnFirstSegment_ReturnsZeroOffset()
        {
            var points = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10)
            };
            var polyline = new Polyline(points);
            var calculator = new Core.Services.StationOffsetCalculator();
            var targetPoint = new Point(5, 0);

            var result = calculator.Calculate(polyline, targetPoint);

            Assert.AreEqual(5, result.Station, 0.0001);
            Assert.AreEqual(0, result.Offset, 0.0001);
            Assert.AreEqual(5, result.NearestPoint.X, 0.0001);
            Assert.AreEqual(0, result.NearestPoint.Y, 0.0001);
        }

        [TestMethod]
        public void Calculate_PointBetweenSegments_ReturnsCorrectOffset()
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
        public void Calculate_PointNearestToSecondSegment_ReturnsCorrectValues()
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

        [TestMethod]
        public void Calculate_DegenerateSegment_HandledGracefully()
        {
            var points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 0),
                new Point(10, 0)
            };
            var polyline = new Polyline(points);
            var calculator = new Core.Services.StationOffsetCalculator();
            var targetPoint = new Point(5, 0);

            var result = calculator.Calculate(polyline, targetPoint);

            Assert.AreEqual(5, result.Station, 0.0001);
            Assert.AreEqual(0, result.Offset, 0.0001);
        }

        [TestMethod]
        public void Calculate_PointFarFromPolyline_ReturnsCorrectOffset()
        {
            var points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 10)
            };
            var polyline = new Polyline(points);
            var calculator = new Core.Services.StationOffsetCalculator();
            var targetPoint = new Point(10, 10);

            var result = calculator.Calculate(polyline, targetPoint);

            Assert.AreEqual(10, result.Station, 0.0001);
            Assert.AreEqual(10, result.Offset, 0.0001);
            Assert.AreEqual(0, result.NearestPoint.X, 0.0001);
            Assert.AreEqual(10, result.NearestPoint.Y, 0.0001);
        }

        [TestMethod]
        public void Calculate_PointWithNegativeCoordinates_WorksCorrectly()
        {
            var points = new List<Point>
            {
                new Point(-10, -10),
                new Point(0, 0),
                new Point(10, 0)
            };
            var polyline = new Polyline(points);
            var calculator = new Core.Services.StationOffsetCalculator();
            var targetPoint = new Point(-5, -5);

            var result = calculator.Calculate(polyline, targetPoint);

            Assert.AreEqual(7.071, result.Station, 0.001);
            Assert.AreEqual(0, result.Offset, 0.0001);
        }

        [TestMethod]
        public void Calculate_PointExactlyOnVertex_ReturnsThatStation()
        {
            var points = new List<Point>
            {
                new Point(0, 0),
                new Point(5, 5),
                new Point(10, 0)
            };
            var polyline = new Polyline(points);
            var calculator = new Core.Services.StationOffsetCalculator();
            var targetPoint = new Point(5, 5);

            var result = calculator.Calculate(polyline, targetPoint);

            Assert.AreEqual(Math.Sqrt(50), result.Station, 0.0001);
            Assert.AreEqual(0, result.Offset, 0.0001);
            Assert.AreEqual(5, result.NearestPoint.X, 0.0001);
            Assert.AreEqual(5, result.NearestPoint.Y, 0.0001);
        }
    }
}