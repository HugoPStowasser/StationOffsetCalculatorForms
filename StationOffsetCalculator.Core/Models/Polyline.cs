using System;
using System.Collections.Generic;

namespace StationOffsetCalculator.Core.Models
{
    public class Polyline
    {
        public List<Point> Points { get; }
        public List<LineSegment> Segments { get; }

        public Polyline(List<Point> points)
        {
            if (points == null || points.Count < 2)
                throw new ArgumentException("Polyline must have at least 2 points");

            Points = points;
            Segments = CreateSegments(Points);
        }

        private List<LineSegment> CreateSegments(List<Point> points)
        {
            var segments = new List<LineSegment>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                segments.Add(new LineSegment(points[i], points[i + 1]));
            }
            return segments;
        }
    }
}