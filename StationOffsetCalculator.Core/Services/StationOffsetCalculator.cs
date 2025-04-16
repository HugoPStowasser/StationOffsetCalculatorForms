using System;
using StationOffsetCalculator.Core.Models;

namespace StationOffsetCalculator.Core.Services
{
    public class StationOffsetCalculator
    {
        public (double Station, double Offset, Point NearestPoint, int SegmentIndex) Calculate(Polyline polyline, Point targetPoint)
        {
            double minDistance = double.MaxValue;
            double station = 0;
            Point nearestPoint = null;
            double currentStation = 0;
            int nearestSegmentIndex = -1;

            for (int i = 0; i < polyline.Segments.Count; i++)
            {
                var segment = polyline.Segments[i];
                var (distanceToSegment, pointOnSegment, distanceAlongSegment) = CalculateDistanceToSegment(segment, targetPoint);

                if (distanceToSegment < minDistance)
                {
                    minDistance = distanceToSegment;
                    station = currentStation + distanceAlongSegment;
                    nearestPoint = pointOnSegment;
                    nearestSegmentIndex = i;
                }

                currentStation += segment.Length;
            }

            return (station, minDistance, nearestPoint, nearestSegmentIndex);
        }

        private (double Distance, Point NearestPoint, double DistanceAlongSegment) CalculateDistanceToSegment(LineSegment segment, Point targetPoint)
        {
            double x1 = segment.Start.X;
            double y1 = segment.Start.Y;
            double x2 = segment.End.X;
            double y2 = segment.End.Y;
            double x0 = targetPoint.X;
            double y0 = targetPoint.Y;

            double dx = x2 - x1;
            double dy = y2 - y1;

            double segmentLengthSquared = dx * dx + dy * dy;

            if (segmentLengthSquared < 1e-10)
            {
                double distanceDegenerate = Math.Sqrt((x0 - x1) * (x0 - x1) + (y0 - y1) * (y0 - y1));
                return (distanceDegenerate, new Point(x1, y1), 0);
            }

            double t = ((x0 - x1) * dx + (y0 - y1) * dy) / segmentLengthSquared;
            t = Math.Max(0, Math.Min(1, t));

            double projectionX = x1 + t * dx;
            double projectionY = y1 + t * dy;
            Point nearestPoint = new Point(projectionX, projectionY);

            double calculatedDistance = Math.Sqrt((x0 - projectionX) * (x0 - projectionX) + (y0 - projectionY) * (y0 - projectionY));
            double distanceAlongSegment = t * segment.Length;

            return (calculatedDistance, nearestPoint, distanceAlongSegment);
        }
    }
}
