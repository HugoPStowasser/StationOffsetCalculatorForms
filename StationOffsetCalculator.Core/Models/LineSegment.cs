namespace StationOffsetCalculator.Core.Models
{
    public class LineSegment
    {
        public Point Start { get; }
        public Point End { get; }
        public double Length { get; }

        public LineSegment(Point start, Point end)
        {
            Start = start;
            End = end;
            Length = CalculateLength();
        }

        private double CalculateLength()
        {
            double dx = End.X - Start.X;
            double dy = End.Y - Start.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}