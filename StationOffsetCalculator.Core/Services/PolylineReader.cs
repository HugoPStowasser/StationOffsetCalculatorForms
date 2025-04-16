using StationOffsetCalculator.Core.Models;

namespace StationOffsetCalculator.Core.Services
{
    public class PolylineReader
    {
        public Polyline ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            var points = new List<Point>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                if (values.Length != 2)
                    continue;

                if (double.TryParse(values[0], out double x) && double.TryParse(values[1], out double y))
                {
                    points.Add(new Point(x, y));
                }
            }

            if (points.Count < 2)
                throw new InvalidDataException("The file must contain at least 2 valid points");

            return new Polyline(points);
        }
    }
}